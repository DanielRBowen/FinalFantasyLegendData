(function () {
  const LOG_PREFIX = "[GameFAQs FFL Downloader][content]";
  const DESIRED_SECTIONS = {
    full: "Full Game Guides",
    indepth: "In-Depth Guides",
    maps: "Maps and Charts"
  };
  const SECTION_MARKER_SELECTOR =
    "h1, h2, h3, h4, h5, h6, [role='heading'], header, .head, [class*='head'], .title, [class*='title'], strong, b";
  const ELIGIBLE_LINK_SELECTOR = "a[href*='/faqs/'], a[href*='/map/']";
  const GUIDE_LINK_REGEX = /\/faqs\/\d+(?:[-/?#]|$)/i;
  const MAP_LINK_REGEX = /\/map\/\d+(?:[-/?#]|$)/i;
  const CHALLENGE_TEXT_REGEX =
    /just a moment|performing security verification|enable javascript and cookies to continue|verify you are human/i;

  let activeDownload = false;
  let statusElement = null;

  function log(...args) {
    console.log(LOG_PREFIX, ...args);
  }

  function logError(...args) {
    console.error(LOG_PREFIX, ...args);
  }

  function normalizeText(value) {
    return (value || "").replace(/\s+/g, " ").trim();
  }

  function classifySection(text) {
    const normalized = normalizeText(text).toLowerCase();
    if (!normalized) return null;

    if (normalized.includes("foreign language")) return "skip";

    if (
      normalized.includes("patch codes") ||
      normalized.includes("action replay") ||
      normalized.includes("codebreaker") ||
      normalized === "codes" ||
      normalized.endsWith(" codes")
    ) {
      return "skip";
    }

    if (normalized.includes("full game guides")) return "full";
    if (normalized.includes("in-depth guides")) return "indepth";
    if (normalized.includes("maps and charts")) return "maps";
    return null;
  }

  function getGameNameFromTitle() {
    const heading = normalizeText(document.querySelector("h1")?.textContent);
    if (heading && !/\sfaqs$/i.test(heading)) {
      return heading;
    }

    const title = normalizeText(document.title);
    const match = title.match(/^(.*?)\s+FAQs/i);
    return (match && normalizeText(match[1])) || heading || "GameFAQs_Game";
  }

  function getContentRoot() {
    return document.querySelector("main") || document.getElementById("content") || document.body;
  }

  function getGamePathPrefix() {
    return location.pathname.replace(/\/faqs\/?$/i, "");
  }

  function looksLikeMarkerElement(element) {
    if (!(element instanceof Element)) return false;

    if (element.matches("h1, h2, h3, h4, h5, h6, [role='heading'], header, strong, b, .head, .title")) {
      return true;
    }

    const className = typeof element.className === "string" ? element.className.toLowerCase() : "";
    return className.includes("head") || className.includes("title");
  }

  function getSectionMarkerFromElement(element) {
    if (!looksLikeMarkerElement(element)) return null;

    const text = normalizeText(element.textContent);
    if (!text || text.length > 120) return null;

    const sectionType = classifySection(text);
    if (!sectionType) return null;

    const childMarkers = Array.from(element.children || []).filter((child) =>
      classifySection(normalizeText(child.textContent))
    );

    if (childMarkers.length > 1 && !element.matches("h1, h2, h3, h4, h5, h6, [role='heading']")) {
      return null;
    }

    return sectionType;
  }

  function getSectionMarkers(root) {
    const markers = [];

    root.querySelectorAll(SECTION_MARKER_SELECTOR).forEach((element) => {
      const sectionType = getSectionMarkerFromElement(element);
      if (!sectionType) return;

      const text = normalizeText(element.textContent);
      const lastMarker = markers[markers.length - 1];

      if (
        lastMarker &&
        lastMarker.sectionType === sectionType &&
        lastMarker.text === text &&
        (lastMarker.element.contains(element) || element.contains(lastMarker.element))
      ) {
        if (element.contains(lastMarker.element)) {
          markers[markers.length - 1] = { element, sectionType, text };
        }
        return;
      }

      markers.push({ element, sectionType, text });
    });

    return markers;
  }

  function isEligibleAnchor(anchor) {
    try {
      const url = new URL(anchor.getAttribute("href"), location.href);
      if (url.origin !== location.origin) return false;
      if (!(GUIDE_LINK_REGEX.test(url.pathname) || MAP_LINK_REGEX.test(url.pathname))) return false;

      const prefix = getGamePathPrefix();
      return url.pathname.startsWith(`${prefix}/`);
    } catch {
      return false;
    }
  }

  function getAnchorTitle(anchor) {
    const candidates = [
      anchor.textContent,
      anchor.getAttribute("aria-label"),
      anchor.getAttribute("title")
    ];

    for (const candidate of candidates) {
      const text = normalizeText(candidate);
      if (text) return text;
    }

    try {
      const url = new URL(anchor.href, location.href);
      return normalizeText(url.pathname.split("/").pop()?.replace(/[-_]+/g, " ")) || "Guide";
    } catch {
      return "Guide";
    }
  }

  function createJob(anchor, sectionType) {
    try {
      const url = new URL(anchor.getAttribute("href"), location.href).href;
      const kind = MAP_LINK_REGEX.test(url) ? "map" : GUIDE_LINK_REGEX.test(url) ? "guide" : null;
      if (!kind) return null;

      return {
        kind,
        sectionType,
        title: getAnchorTitle(anchor),
        url
      };
    } catch {
      return null;
    }
  }

  function addJob(jobs, seen, sectionType, anchor) {
    const job = createJob(anchor, sectionType);
    if (!job) return;

    const key = `${job.kind}:${job.url}`;
    if (seen.has(key)) return;

    seen.add(key);
    jobs.push(job);
  }

  function collectAnchorsBetween(root, startElement, endElement) {
    const anchors = [];
    const walker = document.createTreeWalker(root, NodeFilter.SHOW_ELEMENT);
    let started = false;
    let node = walker.nextNode();

    while (node) {
      if (!started) {
        if (node === startElement) {
          started = true;
        }
        node = walker.nextNode();
        continue;
      }

      if (endElement && node === endElement) {
        break;
      }

      if (node.tagName === "A" && isEligibleAnchor(node)) {
        anchors.push(node);
      }

      node = walker.nextNode();
    }

    return anchors;
  }

  function collectJobsUsingSectionMarkers(root) {
    const jobs = [];
    const seen = new Set();
    const markers = getSectionMarkers(root);

    log(
      "Section markers:",
      markers.map((marker) => `${marker.text} => ${marker.sectionType}`).join(" | ") || "<none>"
    );

    for (let index = 0; index < markers.length; index += 1) {
      const marker = markers[index];
      if (marker.sectionType === "skip") continue;

      const nextMarker = markers[index + 1]?.element || null;
      const anchors = collectAnchorsBetween(root, marker.element, nextMarker);
      log(`Section '${marker.text}' yielded`, anchors.length, "candidate link(s).");

      anchors.forEach((anchor) => addJob(jobs, seen, marker.sectionType, anchor));
    }

    return jobs;
  }

  function collectJobsUsingOrderedFallback(root) {
    const jobs = [];
    const seen = new Set();
    const walker = document.createTreeWalker(root, NodeFilter.SHOW_ELEMENT);
    let currentSection = null;
    let node = walker.nextNode();

    while (node) {
      const marker = getSectionMarkerFromElement(node);
      if (marker) {
        currentSection = marker === "skip" ? null : marker;
        node = walker.nextNode();
        continue;
      }

      if (node.tagName === "A" && currentSection && isEligibleAnchor(node)) {
        addJob(jobs, seen, currentSection, node);
      }

      node = walker.nextNode();
    }

    return jobs;
  }

  function findMarkerWithinElement(element) {
    if (!(element instanceof Element)) return null;

    const direct = getSectionMarkerFromElement(element);
    if (direct) return direct;

    const candidates = Array.from(element.querySelectorAll(SECTION_MARKER_SELECTOR));
    for (let index = candidates.length - 1; index >= 0; index -= 1) {
      const marker = getSectionMarkerFromElement(candidates[index]);
      if (marker) return marker;
    }

    return null;
  }

  function findNearestSectionForAnchor(anchor, root) {
    let node = anchor;

    while (node && node !== root) {
      let sibling = node.previousElementSibling;
      while (sibling) {
        const marker = findMarkerWithinElement(sibling);
        if (marker) return marker;
        sibling = sibling.previousElementSibling;
      }
      node = node.parentElement;
    }

    return null;
  }

  function collectJobsUsingAncestorFallback(root) {
    const jobs = [];
    const seen = new Set();
    const anchors = Array.from(root.querySelectorAll(ELIGIBLE_LINK_SELECTOR)).filter(isEligibleAnchor);

    log("Ancestor fallback anchor count:", anchors.length);

    anchors.forEach((anchor) => {
      const sectionType = findNearestSectionForAnchor(anchor, root);
      if (!sectionType || sectionType === "skip") return;
      addJob(jobs, seen, sectionType, anchor);
    });

    return jobs;
  }

  function collectJobs() {
    const root = getContentRoot();
    const rawEligibleAnchors = root.querySelectorAll(ELIGIBLE_LINK_SELECTOR).length;
    log("Using content root:", root.tagName, "eligible-looking anchors:", rawEligibleAnchors);

    let jobs = collectJobsUsingSectionMarkers(root);
    if (!jobs.length) {
      log("Section marker scan found nothing. Trying ordered fallback.");
      jobs = collectJobsUsingOrderedFallback(root);
    }

    if (!jobs.length) {
      log("Ordered fallback found nothing. Trying ancestor fallback.");
      jobs = collectJobsUsingAncestorFallback(root);
    }

    log("Collected jobs:", jobs);
    return jobs;
  }

  function ensureStatusElement() {
    if (statusElement && document.body.contains(statusElement)) {
      return statusElement;
    }

    statusElement = document.createElement("div");
    statusElement.id = "gffl-download-status";

    Object.assign(statusElement.style, {
      position: "fixed",
      right: "20px",
      bottom: "70px",
      zIndex: 99999,
      maxWidth: "360px",
      padding: "10px 12px",
      borderRadius: "6px",
      background: "rgba(17, 24, 39, 0.92)",
      color: "#fff",
      fontSize: "13px",
      lineHeight: "1.4",
      boxShadow: "0 8px 20px rgba(0, 0, 0, 0.25)"
    });

    document.body.appendChild(statusElement);
    return statusElement;
  }

  function setStatus(message, isError) {
    const element = ensureStatusElement();
    element.textContent = message;
    element.style.background = isError ? "rgba(127, 29, 29, 0.95)" : "rgba(17, 24, 39, 0.92)";
  }

  function sanitizeFilename(name) {
    return (name || "file").replace(/[\s/\\:*?"<>|]+/g, "_").replace(/_+/g, "_").slice(0, 120);
  }

  function buildBaseName(job) {
    const match = job.url.match(/\/(?:faqs|map)\/(\d+)/i);
    const prefix = match ? `${match[1]}_` : "";
    return `${prefix}${sanitizeFilename(job.title || (job.kind === "map" ? "Map" : "Guide"))}`;
  }

  function buildZipPath(job, extension) {
    const sectionDirectory = DESIRED_SECTIONS[job.sectionType] || "Other";
    return `${sectionDirectory}/${buildBaseName(job)}${extension}`;
  }

  function normalizeGuideText(text) {
    const normalized = (text || "")
      .replace(/\u00a0/g, " ")
      .replace(/\r\n/g, "\n")
      .replace(/\r/g, "\n")
      .split("\n")
      .map((line) => line.replace(/[ \t]+$/g, ""))
      .join("\n")
      .trim();

    return normalized ? `${normalized}\n` : "";
  }

  function getDocumentTitle(doc, fallback) {
    const heading = normalizeText(doc.querySelector("h1")?.textContent);
    if (heading) return heading;

    const title = normalizeText(doc.title);
    return title || fallback || "Guide";
  }

  function absolutizeUrl(value, baseUrl) {
    if (!value) return null;
    try {
      return new URL(value, baseUrl).href;
    } catch {
      return null;
    }
  }

  function absolutizeAttributes(container, attributeName, baseUrl) {
    container.querySelectorAll(`[${attributeName}]`).forEach((element) => {
      const value = element.getAttribute(attributeName);
      const absolute = absolutizeUrl(value, baseUrl);
      if (absolute) {
        element.setAttribute(attributeName, absolute);
      }
    });
  }

  function cleanupGuideClone(container, pageUrl) {
    container.querySelectorAll(
      "script, style, noscript, iframe, button, form, nav, footer, aside, .share, .social, .advertisement, .ad"
    ).forEach((element) => element.remove());

    absolutizeAttributes(container, "href", pageUrl);
    absolutizeAttributes(container, "src", pageUrl);
  }

  function escapeHtml(value) {
    return (value || "")
      .replace(/&/g, "&amp;")
      .replace(/</g, "&lt;")
      .replace(/>/g, "&gt;")
      .replace(/\"/g, "&quot;");
  }

  function buildGuideHtmlDocument(title, sourceUrl, bodyHtml) {
    const escapedTitle = escapeHtml(title);
    const escapedSourceUrl = escapeHtml(sourceUrl);

    return `<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>${escapedTitle}</title>
  <style>
    :root {
      color-scheme: light;
      font-family: Georgia, "Times New Roman", serif;
    }

    body {
      margin: 0;
      background: #f5efe2;
      color: #231a11;
    }

    header {
      padding: 2rem 1.5rem 1rem;
      background: linear-gradient(180deg, #f3d9a2, #f5efe2);
      border-bottom: 1px solid #d6c3a3;
    }

    main {
      max-width: 960px;
      margin: 0 auto;
      padding: 1.5rem;
    }

    img {
      max-width: 100%;
      height: auto;
    }

    table {
      border-collapse: collapse;
    }

    th, td {
      border: 1px solid #c8b28d;
      padding: 0.4rem 0.5rem;
    }

    a {
      color: #704214;
    }

    .guide-download-toc {
      margin: 0 0 1.5rem;
      padding: 1rem 1.25rem;
      background: rgba(255, 255, 255, 0.75);
      border: 1px solid #d6c3a3;
    }

    .guide-download-toc h2 {
      margin-top: 0;
    }

    .guide-download-section {
      margin-top: 2rem;
      padding-top: 1.5rem;
      border-top: 1px solid #d6c3a3;
    }

    .guide-download-section:first-of-type {
      margin-top: 0;
      padding-top: 0;
      border-top: 0;
    }

    .guide-download-meta {
      color: #6b4e2e;
      font-size: 0.95rem;
    }
  </style>
</head>
<body>
  <header>
    <h1>${escapedTitle}</h1>
    <p>Source: <a href="${escapedSourceUrl}">${escapedSourceUrl}</a></p>
  </header>
  <main>${bodyHtml}</main>
</body>
</html>`;
  }

  function looksLikeTextGuide(node) {
    if (!node) return false;

    const tagName = (node.tagName || "").toLowerCase();
    if (tagName === "pre") return true;

    const text = node.textContent || node.innerText || "";
    return text.split(/\r?\n/).length > 20;
  }

  function selectGuideContainer(doc) {
    const selectors = [
      "#faqwrap.ffaqbody",
      "#faqwrap",
      ".ffaqbody",
      "pre#faqtext",
      "#faqtext",
      ".faqtext",
      ".faqbody",
      "article .body",
      "article .content",
      "article",
      "main article",
      "main",
      ".ffaq"
    ];

    let fallback = null;

    for (const selector of selectors) {
      const element = doc.querySelector(selector);
      if (!element) continue;

      fallback = fallback || element;
      if (normalizeText(element.textContent).length > 200) {
        return element;
      }
    }

    return fallback || doc.body;
  }

  function getGuideBaseUrl(pageUrl) {
    try {
      const url = new URL(pageUrl);
      const match = url.pathname.match(/^(.*\/faqs\/\d+)(?:\/[^/?#]+)?\/?$/i);
      if (!match) return null;

      url.pathname = match[1];
      url.search = "";
      url.hash = "";
      return url.href;
    } catch {
      return null;
    }
  }

  function normalizeGuideSectionUrl(url) {
    try {
      const parsed = new URL(url, location.href);
      parsed.hash = "";
      return parsed.href;
    } catch {
      return null;
    }
  }

  function isGuideSectionUrl(url, guideBaseUrl) {
    if (!url || !guideBaseUrl) return false;

    try {
      const parsed = new URL(url);
      return parsed.href === guideBaseUrl || parsed.href.startsWith(`${guideBaseUrl}/`);
    } catch {
      return false;
    }
  }

  function isFormattedGuideDocument(doc) {
    return Boolean(
      doc.querySelector("#faqwrap.ffaqbody, #faqwrap .ftoc, #faq_header_wrap .toc_menu, #faq_header_wrap #faq_toc")
    );
  }

  function collectFormattedGuideSectionUrls(doc, pageUrl) {
    const guideBaseUrl = getGuideBaseUrl(pageUrl);
    if (!guideBaseUrl) return [];

    const urls = [];
    const seen = new Set();

    function add(url) {
      const normalized = normalizeGuideSectionUrl(url);
      if (!normalized || !isGuideSectionUrl(normalized, guideBaseUrl)) return;

      const key = normalized.toLowerCase();
      if (seen.has(key)) return;
      seen.add(key);
      urls.push(normalized);
    }

    doc.querySelectorAll("#faqwrap .ftoc a[href], #faq_header_wrap .toc_menu a[href], #faq_header_wrap #faq_toc a[href]")
      .forEach((anchor) => add(anchor.href));

    if (!urls.length) {
      add(pageUrl);
    }

    return urls;
  }

  function cleanFormattedGuideSection(section, pageUrl) {
    cleanupGuideClone(section, pageUrl);
    section.querySelectorAll(
      ".ftoc, .faq_bookmark_jumper, .paginate, .top_link, .contrib_bio, .msg_info, .tipjar, .rec_text, #contrib_rec"
    ).forEach((element) => element.remove());
  }

  function getFormattedGuideSectionContainer(doc) {
    return doc.querySelector("#faqwrap.ffaqbody, #faqwrap, .ffaqbody") || null;
  }

  function getFormattedSectionHeading(section, fallbackTitle) {
    const heading = normalizeText(
      section.querySelector("h1, h2, h3")?.textContent || section.ownerDocument?.querySelector(".page-title")?.textContent
    );
    return heading || fallbackTitle || "Guide Section";
  }

  async function buildFormattedGuidePayload(doc, pageUrl, title, logLocal) {
    const sectionUrls = collectFormattedGuideSectionUrls(doc, pageUrl);
    if (!sectionUrls.length) return null;

    logLocal(`Formatted guide detected; collecting ${sectionUrls.length} section(s).`);

    const sections = [];
    const currentNormalizedUrl = normalizeGuideSectionUrl(pageUrl);

    for (const sectionUrl of sectionUrls) {
      const sectionDoc =
        currentNormalizedUrl && sectionUrl === currentNormalizedUrl
          ? doc
          : await loadDocumentForUrl(sectionUrl, logLocal);

      const container = getFormattedGuideSectionContainer(sectionDoc);
      if (!container) {
        logLocal(`  section skipped; faqwrap not found: ${sectionUrl}`);
        continue;
      }

      const clone = container.cloneNode(true);
      cleanFormattedGuideSection(clone, sectionUrl);

      const contentHtml = clone.innerHTML.trim();
      if (!contentHtml) {
        logLocal(`  section skipped; empty guide content: ${sectionUrl}`);
        continue;
      }

      sections.push({
        heading: getFormattedSectionHeading(clone, getDocumentTitle(sectionDoc, title)),
        url: sectionUrl,
        html: contentHtml
      });
    }

    if (!sections.length) {
      return null;
    }

    const tocHtml = sections.length > 1
      ? `<nav class="guide-download-toc"><h2>Contents</h2><ol>${sections
          .map(
            (section, index) =>
              `<li><a href="#guide-section-${index + 1}">${escapeHtml(section.heading)}</a></li>`
          )
          .join("")}</ol></nav>`
      : "";

    const bodyHtml = `${tocHtml}${sections
      .map(
        (section, index) =>
          `<section class="guide-download-section" id="guide-section-${index + 1}"><p class="guide-download-meta">Source section: <a href="${escapeHtml(
            section.url
          )}">${escapeHtml(section.url)}</a></p>${section.html}</section>`
      )
      .join("")}`;

    return {
      format: ".html",
      content: buildGuideHtmlDocument(title, pageUrl, bodyHtml),
      title
    };
  }

  async function extractGuidePayload(doc, pageUrl, fallbackTitle, logLocal) {
    const title = getDocumentTitle(doc, fallbackTitle);
    const textNode =
      doc.querySelector("pre#faqtext") ||
      doc.querySelector("#faqtext pre") ||
      doc.querySelector(".faqtext pre") ||
      doc.querySelector(".faqbody pre") ||
      doc.querySelector(".ffaq pre") ||
      doc.querySelector("pre");

    if (textNode && looksLikeTextGuide(textNode)) {
      const text = normalizeGuideText(textNode.textContent || textNode.innerText || "");
      if (text) {
        return { format: ".txt", content: text, title };
      }
    }

    if (isFormattedGuideDocument(doc)) {
      const formattedGuide = await buildFormattedGuidePayload(doc, pageUrl, title, logLocal);
      if (formattedGuide) {
        return formattedGuide;
      }
    }

    const container = selectGuideContainer(doc);
    if (!container) return null;

    const clone = container.cloneNode(true);
    cleanupGuideClone(clone, pageUrl);

    const richContent = clone.querySelector("p, h1, h2, h3, h4, ul, ol, table, blockquote, img, a");
    if (richContent) {
      return {
        format: ".html",
        content: buildGuideHtmlDocument(title, pageUrl, clone.innerHTML.trim()),
        title
      };
    }

    const text = normalizeGuideText(clone.textContent || clone.innerText || "");
    if (!text) return null;

    return { format: ".txt", content: text, title };
  }

  function buildRawMapUrl(pageUrl) {
    try {
      const url = new URL(pageUrl);
      const match = url.pathname.match(/^(.*\/map\/)(\d+)/i);
      if (!match) return null;

      url.pathname = `${match[1]}${match[2]}`;
      url.search = "?raw=1";
      url.hash = "";
      return url.href;
    } catch {
      return null;
    }
  }

  function isRejectedMapCandidate(url) {
    try {
      const parsed = new URL(url, location.href);
      const href = parsed.href.toLowerCase();
      const host = parsed.hostname.toLowerCase();

      if (href.startsWith("data:")) return true;
      if (host.includes("paypalobjects.com")) return true;
      if (host.includes("doubleclick.net")) return true;
      if (host.includes("google-analytics.com")) return true;
      if (href.includes("pixel.gif")) return true;
      if (href.includes("/i/scr/")) return true;
      if (href.includes("spacer.")) return true;
      if (href.includes("blank.")) return true;
      return false;
    } catch {
      return true;
    }
  }

  function parseSrcSet(value, baseUrl) {
    if (!value) return [];

    return value
      .split(",")
      .map((entry) => absolutizeUrl(entry.trim().split(/\s+/)[0], baseUrl))
      .filter(Boolean)
      .reverse();
  }

  function getCandidateUrlsFromElement(element, pageUrl) {
    const urls = [];
    const seen = new Set();

    function add(url) {
      if (!url) return;
      const key = url.toLowerCase();
      if (seen.has(key)) return;
      seen.add(key);
      urls.push(url);
    }

    parseSrcSet(element.getAttribute("srcset"), pageUrl).forEach(add);
    add(absolutizeUrl(element.getAttribute("src"), pageUrl));
    add(absolutizeUrl(element.getAttribute("data-src"), pageUrl));
    add(absolutizeUrl(element.getAttribute("data-original"), pageUrl));
    add(absolutizeUrl(element.getAttribute("href"), pageUrl));
    return urls;
  }

  function getElementDimensionScore(element) {
    const width =
      Number(element.getAttribute("width")) ||
      Number(element.getAttribute("data-width")) ||
      Number(element.width) ||
      0;
    const height =
      Number(element.getAttribute("height")) ||
      Number(element.getAttribute("data-height")) ||
      Number(element.height) ||
      0;

    return width * height;
  }

  function collectMapCandidatesFromContainer(container, pageUrl, candidates, seen, reasonPrefix) {
    if (!container) return;

    const preferredLink = container.querySelector("a[href*='raw=1']");
    if (preferredLink) {
      addMapCandidate(candidates, seen, preferredLink.href, `${reasonPrefix} raw link`, 10_000);
    }

    Array.from(container.querySelectorAll("img, source, a[href], [srcset], [data-src], [data-original]"))
      .forEach((element) => {
        const baseScore = getElementDimensionScore(element);
        getCandidateUrlsFromElement(element, pageUrl).forEach((url) => {
          let score = baseScore;
          if (/raw=1/i.test(url)) score += 50_000;
          if (element.tagName === "IMG") score += 5_000;
          addMapCandidate(candidates, seen, url, `${reasonPrefix} ${element.tagName.toLowerCase()}`, score);
        });
      });
  }

  function addMapCandidate(candidates, seen, url, reason, score) {
    if (!url || isRejectedMapCandidate(url)) return;

    const key = url.toLowerCase();
    if (seen.has(key)) return;

    seen.add(key);
    candidates.push({ url, reason, score: score || 0 });
  }

  function extractMapImageCandidates(doc, pageUrl) {
    const candidates = [];
    const seen = new Set();

    addMapCandidate(candidates, seen, buildRawMapUrl(pageUrl), "derived raw url", 100_000);

    const mapContainer = doc.querySelector(
      "#map_container, .map_container, [id*='map_container'], [class*='map_container']"
    );
    collectMapCandidatesFromContainer(mapContainer, pageUrl, candidates, seen, "map_container");

    doc.querySelectorAll("a[href*='raw=1']").forEach((anchor) => {
      addMapCandidate(candidates, seen, anchor.href, "page raw link", 80_000);
    });

    const ogImage = absolutizeUrl(
      doc.querySelector("meta[property='og:image']")?.getAttribute("content"),
      pageUrl
    );
    addMapCandidate(candidates, seen, ogImage, "og:image", 500);

    Array.from(doc.querySelectorAll(".map img, main img, article img, #content img, img"))
      .forEach((image) => {
        const score = getElementDimensionScore(image);
        getCandidateUrlsFromElement(image, pageUrl).forEach((url) => {
          addMapCandidate(candidates, seen, url, "generic image", score);
        });
      });

    return candidates.sort((left, right) => right.score - left.score);
  }

  function isUsableMapBlob(blob, url) {
    if (!blob) return false;
    if (blob.size > 0 && blob.size < 256) return false;

    const type = (blob.type || "").toLowerCase();
    if (type && !type.startsWith("image/")) return false;

    return !isRejectedMapCandidate(url);
  }

  function guessImageExtension(mime, url) {
    const normalizedMime = (mime || "").toLowerCase();
    if (normalizedMime.includes("png")) return ".png";
    if (normalizedMime.includes("jpeg") || normalizedMime.includes("jpg")) return ".jpg";
    if (normalizedMime.includes("gif")) return ".gif";
    if (normalizedMime.includes("webp")) return ".webp";

    try {
      const extension = new URL(url).pathname.match(/\.[a-z0-9]+$/i)?.[0];
      return extension || ".png";
    } catch {
      return ".png";
    }
  }

  function guessImageMimeFromUrl(url) {
    const extension = guessImageExtension("", url).toLowerCase();
    if (extension === ".jpg" || extension === ".jpeg") return "image/jpeg";
    if (extension === ".gif") return "image/gif";
    if (extension === ".webp") return "image/webp";
    return "image/png";
  }

  function isChallengeDocument(doc) {
    const title = normalizeText(doc.title).toLowerCase();
    const bodyText = normalizeText(doc.body?.innerText || doc.body?.textContent || "").toLowerCase();
    return CHALLENGE_TEXT_REGEX.test(title) || CHALLENGE_TEXT_REGEX.test(bodyText);
  }

  async function loadDocumentViaFetch(url) {
    const response = await fetch(url, {
      credentials: "include",
      cache: "no-store"
    });

    if (!response.ok) {
      throw new Error(`HTTP ${response.status} while loading ${url}`);
    }

    const html = await response.text();
    return new DOMParser().parseFromString(html, "text/html");
  }

  async function loadDocumentViaFrame(url) {
    const iframe = document.createElement("iframe");
    iframe.setAttribute("aria-hidden", "true");

    Object.assign(iframe.style, {
      position: "fixed",
      width: "1px",
      height: "1px",
      left: "-9999px",
      top: "-9999px",
      opacity: "0",
      pointerEvents: "none"
    });

    document.documentElement.appendChild(iframe);

    try {
      await new Promise((resolve, reject) => {
        const timeoutId = window.setTimeout(() => {
          cleanup();
          reject(new Error(`Timed out loading ${url} in iframe`));
        }, 30000);

        function cleanup() {
          window.clearTimeout(timeoutId);
          iframe.removeEventListener("load", handleLoad);
          iframe.removeEventListener("error", handleError);
        }

        function handleLoad() {
          cleanup();
          resolve();
        }

        function handleError() {
          cleanup();
          reject(new Error(`Iframe load failed for ${url}`));
        }

        iframe.addEventListener("load", handleLoad, { once: true });
        iframe.addEventListener("error", handleError, { once: true });
        iframe.src = url;
      });

      const doc = iframe.contentDocument;
      if (!doc || !doc.documentElement) {
        throw new Error(`Iframe document was unavailable for ${url}`);
      }

      return new DOMParser().parseFromString(doc.documentElement.outerHTML, "text/html");
    } finally {
      iframe.remove();
    }
  }

  async function loadDocumentForUrl(url, logLocal) {
    const strategies = [
      { name: "iframe", load: () => loadDocumentViaFrame(url) },
      { name: "fetch", load: () => loadDocumentViaFetch(url) }
    ];

    let lastError = null;

    for (const strategy of strategies) {
      try {
        logLocal(`Loading page with ${strategy.name}: ${url}`);
        const doc = await strategy.load();
        if (isChallengeDocument(doc)) {
          throw new Error(`GameFAQs returned a security challenge for ${url}`);
        }
        return doc;
      } catch (error) {
        lastError = error;
        logLocal(`  ${strategy.name} load failed: ${error.message || String(error)}`);
      }
    }

    throw lastError || new Error(`Unable to load ${url}`);
  }

  async function loadBlobViaFetch(url) {
    const response = await fetch(url, {
      credentials: "include",
      cache: "no-store"
    });

    if (!response.ok) {
      throw new Error(`HTTP ${response.status} while loading ${url}`);
    }

    return response.blob();
  }

  async function loadBlobViaImage(url) {
    return new Promise((resolve, reject) => {
      const image = new Image();
      image.decoding = "sync";

      image.onload = () => {
        try {
          const canvas = document.createElement("canvas");
          canvas.width = image.naturalWidth || image.width;
          canvas.height = image.naturalHeight || image.height;

          const context = canvas.getContext("2d");
          if (!context) {
            reject(new Error(`Canvas context was unavailable for ${url}`));
            return;
          }

          context.drawImage(image, 0, 0);
          canvas.toBlob(
            (blob) => {
              if (!blob) {
                reject(new Error(`Canvas export failed for ${url}`));
                return;
              }
              resolve(blob);
            },
            guessImageMimeFromUrl(url)
          );
        } catch (error) {
          reject(error);
        }
      };

      image.onerror = () => reject(new Error(`Image load failed for ${url}`));
      image.src = url;
    });
  }

  async function loadBlobForUrl(url, logLocal) {
    const strategies = [
      { name: "fetch", load: () => loadBlobViaFetch(url) },
      { name: "image", load: () => loadBlobViaImage(url) }
    ];

    let lastError = null;

    for (const strategy of strategies) {
      try {
        logLocal(`Loading binary with ${strategy.name}: ${url}`);
        return await strategy.load();
      } catch (error) {
        lastError = error;
        logLocal(`  ${strategy.name} binary load failed: ${error.message || String(error)}`);
      }
    }

    throw lastError || new Error(`Unable to load binary content from ${url}`);
  }

  async function processGuide(job, zip, logLocal) {
    const doc = await loadDocumentForUrl(job.url, logLocal);
    const guide = await extractGuidePayload(doc, job.url, job.title, logLocal);

    if (!guide || !guide.content) {
      throw new Error(`Guide content was not found for ${job.url}`);
    }

    const zipPath = buildZipPath(job, guide.format);
    zip.file(zipPath, guide.content);
    logLocal(`Saved guide: ${zipPath}`);
  }

  async function processMap(job, zip, logLocal) {
    const doc = await loadDocumentForUrl(job.url, logLocal);
    const candidates = extractMapImageCandidates(doc, job.url);

    if (!candidates.length) {
      throw new Error(`Map image URL was not found for ${job.url}`);
    }

    logLocal(
      `Map candidates: ${candidates
        .slice(0, 6)
        .map((candidate) => `${candidate.reason} => ${candidate.url}`)
        .join(" | ")}`
    );

    let lastError = null;

    for (const candidate of candidates) {
      try {
        const imageBlob = await loadBlobForUrl(candidate.url, logLocal);
        if (!isUsableMapBlob(imageBlob, candidate.url)) {
          throw new Error(`Rejected unusable image candidate ${candidate.url}`);
        }

        const zipPath = buildZipPath(job, guessImageExtension(imageBlob.type, candidate.url));
        zip.file(zipPath, imageBlob);
        logLocal(`Saved map: ${zipPath}`);
        return;
      } catch (error) {
        lastError = error;
        logLocal(`  candidate failed (${candidate.reason}): ${error.message || String(error)}`);
      }
    }

    throw lastError || new Error(`Map image could not be downloaded for ${job.url}`);
  }

  function triggerBlobDownload(blob, filename) {
    const objectUrl = URL.createObjectURL(blob);
    const anchor = document.createElement("a");
    anchor.href = objectUrl;
    anchor.download = filename;
    document.body.appendChild(anchor);
    anchor.click();
    anchor.remove();

    window.setTimeout(() => {
      URL.revokeObjectURL(objectUrl);
    }, 60000);
  }

  async function downloadAllJobs(gameName, jobs, button) {
    if (activeDownload) return;

    if (typeof JSZip !== "function") {
      throw new Error("JSZip was not loaded in the content script. Reload the extension and try again.");
    }

    activeDownload = true;
    const originalText = button.textContent;
    const logs = [];
    const zip = new JSZip();
    let completed = 0;
    let skipped = 0;

    function logLocal(...args) {
      const line = args
        .map((value) => (typeof value === "string" ? value : JSON.stringify(value)))
        .join(" ");

      logs.push(line);
      log(line);
      setStatus(line, false);
    }

    try {
      button.disabled = true;
      button.style.cursor = "progress";

      logLocal(`Starting ${jobs.length} item(s) for ${gameName}.`);

      for (let index = 0; index < jobs.length; index += 1) {
        const job = jobs[index];
        button.textContent = `Downloading ${index + 1}/${jobs.length}`;
        setStatus(`Downloading ${index + 1}/${jobs.length}: ${job.title}`, false);

        try {
          if (job.kind === "map") {
            await processMap(job, zip, logLocal);
          } else {
            await processGuide(job, zip, logLocal);
          }
          completed += 1;
        } catch (error) {
          skipped += 1;
          logLocal(`Skipped ${job.url}: ${error.message || String(error)}`);
        }
      }

      zip.file("log.txt", logs.join("\n"));
      button.textContent = "Building ZIP";

      const zipBlob = await zip.generateAsync({ type: "blob" }, (metadata) => {
        setStatus(`Building ZIP: ${Math.round(metadata.percent)}%`, false);
      });

      const safeGameName = sanitizeFilename(gameName).replace(/_+/g, "_") || "GameFAQs_Game";
      const filename = `${safeGameName}_guides.zip`;
      triggerBlobDownload(zipBlob, filename);

      setStatus(`Downloaded ${completed} item(s). Skipped ${skipped}.`, false);
      alert(`Download ready: ${filename}\nSaved ${completed} item(s). Skipped ${skipped}.`);
    } finally {
      button.disabled = false;
      button.style.cursor = "pointer";
      button.textContent = originalText;
      activeDownload = false;
    }
  }

  function addButton() {
    if (document.getElementById("gffl-download-all-btn")) return;

    const button = document.createElement("button");
    button.id = "gffl-download-all-btn";
    button.textContent = "Download All Guides (ZIP)";

    Object.assign(button.style, {
      position: "fixed",
      bottom: "20px",
      right: "20px",
      zIndex: 99999,
      padding: "10px 14px",
      background: "#2c7be5",
      color: "#fff",
      border: "none",
      borderRadius: "4px",
      cursor: "pointer",
      fontSize: "14px",
      boxShadow: "0 2px 6px rgba(0,0,0,0.25)"
    });

    button.addEventListener("mouseenter", () => {
      if (!button.disabled) {
        button.style.background = "#1b5bb8";
      }
    });

    button.addEventListener("mouseleave", () => {
      button.style.background = "#2c7be5";
    });

    button.addEventListener("click", async () => {
      if (activeDownload) return;

      try {
        const jobs = collectJobs();
        if (!jobs.length) {
          const root = getContentRoot();
          const rawEligibleAnchors = root.querySelectorAll(ELIGIBLE_LINK_SELECTOR).length;
          alert(
            `No eligible guides or maps were found on this page. Raw FAQ/map links seen in the content area: ${rawEligibleAnchors}. Open the page console for details.`
          );
          return;
        }

        const gameName = getGameNameFromTitle();
        log("Starting in-page download for game:", gameName, "jobs:", jobs.length);
        await downloadAllJobs(gameName, jobs, button);
      } catch (error) {
        logError("Fatal download error:", error);
        setStatus(error.message || String(error), true);
        alert(`Download failed: ${error.message || String(error)}`);
      }
    });

    document.body.appendChild(button);
    log("Download button injected.");
  }

  if (document.readyState === "complete" || document.readyState === "interactive") {
    addButton();
  } else {
    window.addEventListener("DOMContentLoaded", addButton, { once: true });
  }
})();
