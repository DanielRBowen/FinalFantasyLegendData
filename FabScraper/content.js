let assetMap = new Map();
let scrapeLog = [];
let isScraping = false;

const MAX_LOG_ENTRIES = 250;
const STABLE_TICK_LIMIT = 10;
const MAX_SCROLL_TICKS = 180;
const WAIT_BETWEEN_TICKS_MS = 900;
const DETAIL_ENRICHMENT_DELAY_MS = 350;
const GENERIC_TEXT_VALUES = new Set([
  "",
  "view",
  "open",
  "details",
  "library",
  "owned",
  "download",
  "add to cart",
  "wishlist"
]);
const NON_CATEGORY_VALUES = new Set([
  "unknown",
  "overview",
  "reviews",
  "details",
  "description",
  "included formats",
  "tags",
  "other information",
  "compatibility"
]);
const STRICT_CATEGORIES = [
  "Characters",
  "Animations",
  "VFX",
  "Audio",
  "Materials",
  "Tools",
  "UI",
  "Props",
  "Environments",
  "Vehicles",
  "Weapons",
  "Blueprints",
  "Plugins",
  "Scenes",
  "Other"
];
const CATEGORY_RULES = [
  { category: "Characters", patterns: [/character/i, /npc/i, /creature/i, /humanoid/i, /monster/i] },
  { category: "Animations", patterns: [/animation/i, /animset/i, /motion/i, /moveset/i] },
  { category: "VFX", patterns: [/vfx/i, /effect/i, /particle/i, /explosion/i, /flare/i, /magic/i] },
  { category: "Audio", patterns: [/audio/i, /sound/i, /music/i, /ambience/i, /sfx/i] },
  { category: "Materials", patterns: [/material/i, /shader/i, /texture/i, /surface/i, /decal/i] },
  { category: "Plugins", patterns: [/plugin/i] },
  { category: "Blueprints", patterns: [/blueprint/i] },
  { category: "Tools", patterns: [/tool/i, /system/i, /utility/i, /framework/i, /spawner/i] },
  { category: "UI", patterns: [/(^|\W)ui(\W|$)/i, /widget/i, /hud/i, /interface/i, /menu/i] },
  { category: "Weapons", patterns: [/weapon/i, /rifle/i, /gun/i, /sword/i, /melee/i] },
  { category: "Vehicles", patterns: [/vehicle/i, /car/i, /truck/i, /tank/i, /aircraft/i, /spaceship/i] },
  { category: "Props", patterns: [/prop/i, /furniture/i, /pack/i, /asset pack/i, /kitbash/i] },
  { category: "Scenes", patterns: [/scene/i, /template/i, /sample project/i] },
  { category: "Environments", patterns: [/environment/i, /building/i, /architecture/i, /dungeon/i, /forest/i, /town/i, /city/i, /landscape/i, /level/i, /graveyard/i, /castle/i, /village/i] }
];

function delay(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

function safeSendMessage(message) {
  try {
    chrome.runtime.sendMessage(message, () => void chrome.runtime.lastError);
  } catch (error) {
    console.debug("Fab Library Exporter: popup unavailable", error);
  }
}

function logEvent(level, message, details = null) {
  const entry = {
    time: new Date().toISOString(),
    level,
    message,
    details
  };

  scrapeLog.push(entry);
  if (scrapeLog.length > MAX_LOG_ENTRIES) {
    scrapeLog = scrapeLog.slice(-MAX_LOG_ENTRIES);
  }

  const logger = console[level] || console.log;
  if (details) {
    logger(`Fab Library Exporter: ${message}`, details);
  } else {
    logger(`Fab Library Exporter: ${message}`);
  }

  safeSendMessage({ action: "SCRAPE_LOG", entry });
}

function getText(value) {
  return (value || "").replace(/\s+/g, " ").trim();
}

function normalizeUrl(url) {
  try {
    return new URL(url, window.location.href).href;
  } catch {
    return "";
  }
}

function isLikelyVisible(element) {
  if (!element) {
    return false;
  }

  const style = window.getComputedStyle(element);
  if (style.display === "none" || style.visibility === "hidden") {
    return false;
  }

  const rect = element.getBoundingClientRect();
  return rect.width > 0 && rect.height > 0;
}

function normalizeName(value) {
  const text = getText(value);
  if (!text) {
    return "";
  }

  const lower = text.toLowerCase();
  if (GENERIC_TEXT_VALUES.has(lower)) {
    return "";
  }

  return text;
}

function isUnknownCategory(value) {
  const text = getText(value).toLowerCase();
  if (!text) {
    return true;
  }

  if (NON_CATEGORY_VALUES.has(text)) {
    return true;
  }

  return text === "unknown";
}

function getListingSlug(url) {
  try {
    const parsed = new URL(url, window.location.href);
    const parts = parsed.pathname.split("/").filter(Boolean);
    const index = parts.indexOf("listings");
    if (index >= 0 && parts[index + 1]) {
      return decodeURIComponent(parts[index + 1]).replace(/-/g, " ");
    }
  } catch {
    return "";
  }

  return "";
}

function getAllCandidateTexts(card, anchor) {
  const candidates = [];
  const push = value => {
    const text = normalizeName(value);
    if (text && !candidates.includes(text)) {
      candidates.push(text);
    }
  };

  push(anchor.getAttribute("aria-label"));
  push(anchor.getAttribute("title"));
  push(anchor.textContent);

  const elements = card.querySelectorAll("h1, h2, h3, h4, [title], [aria-label], img[alt]");
  elements.forEach(element => {
    push(element.getAttribute?.("title"));
    push(element.getAttribute?.("aria-label"));
    push(element.getAttribute?.("alt"));
    push(element.textContent);
  });

  push(getListingSlug(anchor.href));
  return candidates;
}

function pickName(card, anchor) {
  const candidates = getAllCandidateTexts(card, anchor);
  return candidates[0] || "";
}

function pickThumbnail(card) {
  const image = card.querySelector("img[src]");
  return image?.src || image?.getAttribute("src") || "";
}

function pickCreator(card) {
  const textNodes = Array.from(card.querySelectorAll("span, div, p, a"))
    .map(node => getText(node.textContent))
    .filter(Boolean)
    .filter(text => text.length <= 80);

  const byLine = textNodes.find(text => /^by\s+/i.test(text));
  if (byLine) {
    return byLine.replace(/^by\s+/i, "").trim();
  }

  return "Unknown Creator";
}

function pickCategory(card) {
  const badge = Array.from(card.querySelectorAll("span, div, p"))
    .map(node => getText(node.textContent))
    .find(text => /plugin|environment|material|audio|tool|character|animation|vfx|ui|template|props/i.test(text));

  return badge || "Unknown";
}

function pickCreatorFromDocument(doc) {
  const creatorLink = doc.querySelector('a[href*="/sellers/"]');
  const creatorText = getText(creatorLink?.textContent);
  return creatorText || "Unknown Creator";
}

function normalizeCategoryCandidate(value) {
  const text = getText(value)
    .replace(/^browse\s+/i, "")
    .replace(/^go to\s+/i, "")
    .replace(/\s+/g, " ")
    .trim();

  if (!text) {
    return "";
  }

  if (NON_CATEGORY_VALUES.has(text.toLowerCase())) {
    return "";
  }

  return text;
}

function extractCategoriesFromDocument(doc) {
  const categoryLinks = Array.from(doc.querySelectorAll('a[href*="/category/"]'));
  const candidates = categoryLinks
    .map(link => normalizeCategoryCandidate(link.textContent))
    .filter(Boolean);

  const filtered = candidates.filter(candidate => !/^3d$/i.test(candidate) && !/^game engines$/i.test(candidate));
  return [...new Set(filtered)];
}

function extractDescriptionFromDocument(doc) {
  const heading = Array.from(doc.querySelectorAll("h2, h3")).find(node => /description/i.test(getText(node.textContent)));
  if (heading) {
    const chunks = [];
    let current = heading.nextElementSibling;
    while (current && !/^h[1-3]$/i.test(current.tagName)) {
      const text = getText(current.textContent);
      if (text) {
        chunks.push(text);
      }
      if (chunks.join(" ").length > 4000) {
        break;
      }
      current = current.nextElementSibling;
    }

    const description = getText(chunks.join(" "));
    if (description) {
      return description;
    }
  }

  const metaDescription = doc.querySelector('meta[name="description"]')?.getAttribute("content");
  return getText(metaDescription);
}

function inferCategoryFromText(...values) {
  const haystack = values.map(getText).filter(Boolean).join(" \n ");
  if (!haystack) {
    return "Unknown";
  }

  for (const rule of CATEGORY_RULES) {
    if (rule.patterns.some(pattern => pattern.test(haystack))) {
      return rule.category;
    }
  }

  return "Other";
}

function mapToStrictCategory(...values) {
  const haystack = values.map(getText).filter(Boolean).join(" \n ");
  if (!haystack) {
    return "Other";
  }

  const directMatch = STRICT_CATEGORIES.find(category => new RegExp(`(^|\\W)${category.replace(/s$/, "s?")}(\\W|$)`, "i").test(haystack));
  if (directMatch) {
    return directMatch;
  }

  if (/buildings?\s*&\s*architecture|architecture|building/i.test(haystack)) {
    return "Environments";
  }

  if (/nature|foliage|vegetation|trees?|plants?/i.test(haystack)) {
    return "Environments";
  }

  if (/fx|post process|post-processing/i.test(haystack)) {
    return "VFX";
  }

  if (/character creator|avatar/i.test(haystack)) {
    return "Characters";
  }

  return inferCategoryFromText(haystack);
}

async function enrichAssetFromListingPage(asset, index, total) {
  logEvent("info", "Fetching listing details.", {
    index,
    total,
    name: asset.name,
    url: asset.url
  });

  safeSendMessage({
    action: "SCRAPE_PROGRESS",
    count: assetMap.size,
    stage: "details",
    detailProgress: `${index}/${total}`
  });

  const response = await fetch(asset.url, {
    credentials: "include",
    headers: {
      "accept": "text/html,application/xhtml+xml"
    }
  });

  if (!response.ok) {
    throw new Error(`Listing fetch failed with status ${response.status}`);
  }

  const html = await response.text();
  const doc = new DOMParser().parseFromString(html, "text/html");
  const categoryCandidates = extractCategoriesFromDocument(doc);
  const description = extractDescriptionFromDocument(doc);
  const rawCategory = categoryCandidates.at(-1) || asset.rawCategory || asset.category;
  const strictCategory = mapToStrictCategory(asset.name, description, categoryCandidates.join(" "), rawCategory);
  const creator = pickCreatorFromDocument(doc);

  return {
    ...asset,
    creator: asset.creator === "Unknown Creator" ? creator : asset.creator,
    rawCategory,
    category: strictCategory,
    description: description || asset.description || "",
    categorySource: categoryCandidates.length > 0 ? "listing-page" : "description-inference",
    categoryPath: categoryCandidates
  };
}

async function enrichAssetCategories(assets) {
  const assetsNeedingDetails = assets.filter(asset => isUnknownCategory(asset.rawCategory) || asset.creator === "Unknown Creator");

  if (assetsNeedingDetails.length === 0) {
    logEvent("info", "No detail enrichment needed.", { assetCount: assets.length });
    return assets;
  }

  logEvent("info", "Starting detail enrichment.", {
    assetsToEnrich: assetsNeedingDetails.length,
    totalAssets: assets.length
  });

  const enrichedByUrl = new Map();

  for (let index = 0; index < assetsNeedingDetails.length; index += 1) {
    const asset = assetsNeedingDetails[index];
    try {
      const enriched = await enrichAssetFromListingPage(asset, index + 1, assetsNeedingDetails.length);
      enrichedByUrl.set(asset.url, enriched);
    } catch (error) {
      logEvent("warn", "Failed to enrich asset from listing page.", {
        name: asset.name,
        url: asset.url,
        error: error?.message || String(error)
      });

      const fallbackCategory = inferCategoryFromText(asset.name);
      const strictFallbackCategory = mapToStrictCategory(asset.name, asset.rawCategory, asset.category);
      enrichedByUrl.set(asset.url, {
        ...asset,
        category: strictFallbackCategory,
        rawCategory: asset.rawCategory || asset.category,
        categorySource: fallbackCategory !== "Other" ? "title-inference" : "library-card"
      });
    }

    await delay(DETAIL_ENRICHMENT_DELAY_MS);
  }

  return assets.map(asset => enrichedByUrl.get(asset.url) || asset);
}

function getListingAnchors(root = document) {
  return Array.from(root.querySelectorAll('a[href*="/listings/"]')).filter(anchor => {
    const href = normalizeUrl(anchor.getAttribute("href") || anchor.href);
    return href.includes("/listings/") && href.includes("fab.com") && isLikelyVisible(anchor);
  });
}

function getCardElement(anchor) {
  return anchor.closest('article, li, [role="listitem"], [data-testid*="card"], [class*="Card"], [class*="card"], [class*="Item"], [class*="tile"]') || anchor.parentElement || anchor;
}

function describeElement(element) {
  if (!element) {
    return "null";
  }

  if (element === document.scrollingElement || element === document.documentElement || element === document.body) {
    return "document";
  }

  const id = element.id ? `#${element.id}` : "";
  const className = typeof element.className === "string"
    ? `.${element.className.trim().split(/\s+/).filter(Boolean).slice(0, 3).join(".")}`
    : "";

  return `${element.tagName?.toLowerCase() || "unknown"}${id}${className}`;
}

function findBestScrollRoot() {
  const candidates = [document.scrollingElement, document.documentElement, document.body];
  const allElements = Array.from(document.querySelectorAll("main, section, div"));

  allElements.forEach(element => {
    const style = window.getComputedStyle(element);
    const overflowY = style.overflowY;
    const isScrollable = (overflowY === "auto" || overflowY === "scroll") && element.scrollHeight > element.clientHeight + 200;
    if (isScrollable) {
      candidates.push(element);
    }
  });

  let best = document.scrollingElement || document.documentElement;
  let bestScore = -1;

  candidates.forEach(candidate => {
    if (!candidate) {
      return;
    }

    const anchorCount = getListingAnchors(candidate).length;
    const score = anchorCount * 1000 + (candidate.scrollHeight - candidate.clientHeight);
    if (score > bestScore) {
      best = candidate;
      bestScore = score;
    }
  });

  return best;
}

function getScrollTop(scrollRoot) {
  if (scrollRoot === document.scrollingElement || scrollRoot === document.documentElement || scrollRoot === document.body) {
    return window.scrollY || document.documentElement.scrollTop || document.body.scrollTop || 0;
  }

  return scrollRoot.scrollTop;
}

function getMaxScrollTop(scrollRoot) {
  if (scrollRoot === document.scrollingElement || scrollRoot === document.documentElement || scrollRoot === document.body) {
    return Math.max(0, (document.documentElement.scrollHeight || document.body.scrollHeight) - window.innerHeight);
  }

  return Math.max(0, scrollRoot.scrollHeight - scrollRoot.clientHeight);
}

function advanceScroll(scrollRoot) {
  const step = Math.max(500, Math.floor(window.innerHeight * 0.85));
  const previousTop = getScrollTop(scrollRoot);

  if (scrollRoot === document.scrollingElement || scrollRoot === document.documentElement || scrollRoot === document.body) {
    window.scrollBy(0, step);
  } else {
    scrollRoot.scrollTop += step;
  }

  return getScrollTop(scrollRoot) !== previousTop;
}

function parseVisibleItems() {
  const anchors = getListingAnchors();
  let discoveredThisPass = 0;

  anchors.forEach(anchor => {
    const url = normalizeUrl(anchor.getAttribute("href") || anchor.href);
    if (!url) {
      return;
    }

    const card = getCardElement(anchor);
    const name = pickName(card, anchor);
    if (!name) {
      return;
    }

    const assetKey = url;
    const existing = assetMap.get(assetKey);
    const nextAsset = {
      name,
      creator: pickCreator(card),
      rawCategory: pickCategory(card),
      category: mapToStrictCategory(name, pickCategory(card)),
      url,
      thumbnail: pickThumbnail(card)
    };

    if (!existing) {
      discoveredThisPass += 1;
    }

    assetMap.set(assetKey, {
      ...existing,
      ...nextAsset
    });
  });

  safeSendMessage({ action: "SCRAPE_PROGRESS", count: assetMap.size, visibleAnchors: anchors.length });
  return { visibleAnchors: anchors.length, discoveredThisPass };
}

function buildDiagnostics(scrollRoot, ticksRun) {
  return {
    pageTitle: document.title,
    url: window.location.href,
    readyState: document.readyState,
    scrollRoot: describeElement(scrollRoot),
    scrollTop: getScrollTop(scrollRoot),
    maxScrollTop: getMaxScrollTop(scrollRoot),
    listingAnchorCount: getListingAnchors().length,
    headings: Array.from(document.querySelectorAll("h1, h2, h3")).map(node => getText(node.textContent)).filter(Boolean).slice(0, 12),
    ticksRun,
    log: scrapeLog.map(entry => ({ ...entry }))
  };
}

function downloadJson(filename, payload) {
  const blob = new Blob([JSON.stringify(payload, null, 2)], { type: "application/json" });
  const downloadUrl = URL.createObjectURL(blob);
  const downloadLink = document.createElement("a");

  downloadLink.href = downloadUrl;
  downloadLink.download = filename;
  document.body.appendChild(downloadLink);
  downloadLink.click();
  document.body.removeChild(downloadLink);
  URL.revokeObjectURL(downloadUrl);
}

async function runProgressiveScrollEngine() {
  if (isScraping) {
    logEvent("warn", "Scrape request ignored because a run is already in progress.");
    return;
  }

  isScraping = true;
  scrapeLog = [];
  assetMap.clear();

  const scrollRoot = findBestScrollRoot();
  logEvent("info", "Scrape started.", {
    url: window.location.href,
    title: document.title,
    scrollRoot: describeElement(scrollRoot)
  });

  let stableTicks = 0;
  let previousAssetCount = 0;
  let previousScrollTop = -1;
  let ticksRun = 0;

  try {
    while (stableTicks < STABLE_TICK_LIMIT && ticksRun < MAX_SCROLL_TICKS) {
      const { visibleAnchors, discoveredThisPass } = parseVisibleItems();
      const currentAssetCount = assetMap.size;
      const moved = advanceScroll(scrollRoot);

      await delay(WAIT_BETWEEN_TICKS_MS);

      const currentScrollTop = getScrollTop(scrollRoot);
      const atBottom = currentScrollTop >= getMaxScrollTop(scrollRoot);
      const madeProgress = currentAssetCount > previousAssetCount || currentScrollTop > previousScrollTop || discoveredThisPass > 0;

      if (madeProgress) {
        stableTicks = 0;
      } else {
        stableTicks += 1;
      }

      ticksRun += 1;

      if (ticksRun === 1 || ticksRun % 5 === 0 || discoveredThisPass > 0 || stableTicks >= STABLE_TICK_LIMIT) {
        logEvent("info", "Scrape tick completed.", {
          tick: ticksRun,
          visibleAnchors,
          discoveredThisPass,
          assetCount: currentAssetCount,
          moved,
          atBottom,
          stableTicks
        });
      }

      previousAssetCount = currentAssetCount;
      previousScrollTop = currentScrollTop;

      if (atBottom && !madeProgress) {
        stableTicks += 1;
      }
    }

    const scrapedLibrary = Array.from(assetMap.values());
    const finalLibrary = await enrichAssetCategories(scrapedLibrary);
    logEvent("info", "Scrape finished.", {
      assetCount: finalLibrary.length,
      ticksRun,
      otherCategoriesRemaining: finalLibrary.filter(asset => asset.category === "Other").length
    });

    if (finalLibrary.length > 0) {
      downloadJson("my_fab_library.json", finalLibrary);
      safeSendMessage({ action: "SCRAPE_COMPLETE", count: finalLibrary.length, diagnosticsIncluded: false });
    } else {
      const diagnostics = buildDiagnostics(scrollRoot, ticksRun);
      downloadJson("fab_library_diagnostics.json", diagnostics);
      safeSendMessage({
        action: "SCRAPE_COMPLETE",
        count: 0,
        diagnosticsIncluded: true,
        message: "No assets were extracted. Diagnostics file downloaded."
      });
      logEvent("warn", "No assets extracted. Downloaded diagnostics file.", diagnostics);
    }
  } catch (error) {
    const details = {
      message: error?.message || String(error),
      stack: error?.stack || null
    };
    logEvent("error", "Scrape failed with an exception.", details);
    const diagnostics = buildDiagnostics(scrollRoot, ticksRun);
    diagnostics.error = details;
    downloadJson("fab_library_diagnostics.json", diagnostics);
    safeSendMessage({
      action: "SCRAPE_COMPLETE",
      count: assetMap.size,
      diagnosticsIncluded: true,
      message: "Scrape failed. Diagnostics file downloaded."
    });
  } finally {
    isScraping = false;
  }
}

chrome.runtime.onMessage.addListener((message, sender, sendResponse) => {
  if (message.action === "START_SCRAPE") {
    runProgressiveScrollEngine();
    sendResponse({ ok: true });
  }
});