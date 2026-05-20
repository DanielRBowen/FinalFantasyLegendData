importScripts("jszip.min.js");

const LOG_PREFIX = "[GameFAQs FFL Downloader][background]";

function log(...args) {
  console.log(LOG_PREFIX, ...args);
}

chrome.runtime.onMessage.addListener((msg, sender, sendResponse) => {
  if (msg.action === "downloadAllFFL") {
    handleDownloadAll(msg, sender);
    sendResponse({ status: "started" });
  }
  return true;
});

async function handleDownloadAll(msg, sender) {
  const { gameName, jobs } = msg;
  const logs = [];
  const zip = new JSZip();

  function logLocal(...args) {
    const line = args.map(a => (typeof a === "string" ? a : JSON.stringify(a))).join(" ");
    logs.push(line);
    log(line);
  }

  logLocal("Starting batch for game:", gameName, "jobs:", jobs.length);

  for (let i = 0; i < jobs.length; i++) {
    const job = jobs[i];
    logLocal(`Job ${i + 1}/${jobs.length}:`, job.kind, job.url);

    try {
      if (job.kind === "guide") {
        await processGuide(job, zip, logLocal);
      } else if (job.kind === "map") {
        await processMap(job, zip, logLocal);
      } else {
        logLocal("Unknown job kind, skipping:", job.kind);
      }
    } catch (err) {
      logLocal("Error processing job:", job.url, String(err));
    }
  }

  zip.file("log.txt", logs.join("\n"));

  const zipBlob = await zip.generateAsync({ type: "blob" });
  const dataUrl = await blobToDataUrl(zipBlob);

  const safeGameName = sanitizeFilename(gameName).replace(/\s+/g, "_") || "GameFAQs_Game";
  const filename = `${safeGameName}_guides.zip`;

  if (sender.tab && sender.tab.id != null) {
    chrome.tabs.sendMessage(sender.tab.id, {
      action: "downloadZip",
      dataUrl,
      filename
    });
    logLocal("ZIP sent to tab:", sender.tab.id, "filename:", filename);
  } else {
    logLocal("No sender tab to send ZIP to.");
  }
}

async function processGuide(job, zip, logLocal) {
  const res = await fetch(job.url);
  const html = await res.text();

  const doc = new DOMParser().parseFromString(html, "text/html");

  let textNode =
    doc.querySelector("#faqtext") ||
    doc.querySelector(".faqtext") ||
    doc.querySelector(".faqbody") ||
    doc.querySelector("article");

  let isPlainText = false;
  let content = "";

  if (textNode) {
    if (textNode.tagName && textNode.tagName.toLowerCase() === "pre") {
      content = textNode.textContent || "";
      isPlainText = true;
    } else {
      content = textNode.textContent || "";
      isPlainText = true;
    }
  } else {
    logLocal("Guide main container not found, falling back to full body text.");
    content = doc.body ? doc.body.textContent || "" : html;
    isPlainText = true;
  }

  const baseName = sanitizeFilename(job.title || "Guide");
  const sectionPrefix = job.sectionType ? `${job.sectionType}_` : "";
  const filename = `${sectionPrefix}${baseName}.${isPlainText ? "txt" : "html"}`;

  zip.file(filename, content);
  logLocal("Guide added to ZIP:", filename);
}

async function processMap(job, zip, logLocal) {
  const res = await fetch(job.url);
  const html = await res.text();

  const doc = new DOMParser().parseFromString(html, "text/html");

  let img =
    doc.querySelector(".map img") ||
    doc.querySelector("#content img") ||
    doc.querySelector("article img") ||
    doc.querySelector("img");

  if (!img || !img.src) {
    logLocal("No image found on map page:", job.url);
    return;
  }

  let imgUrl = img.src;
  if (imgUrl.startsWith("//")) {
    imgUrl = "https:" + imgUrl;
  } else if (imgUrl.startsWith("/")) {
    const u = new URL(job.url);
    imgUrl = `${u.origin}${imgUrl}`;
  }

  logLocal("Fetching map image:", imgUrl);

  const imgRes = await fetch(imgUrl);
  const imgBlob = await imgRes.blob();

  const baseName = sanitizeFilename(job.title || "Map");
  const sectionPrefix = job.sectionType ? `${job.sectionType}_` : "";
  const ext = guessImageExtension(imgBlob.type) || "png";
  const filename = `${sectionPrefix}${baseName}.${ext}`;

  zip.file(filename, imgBlob);
  logLocal("Map image added to ZIP:", filename);
}

function sanitizeFilename(name) {
  return (name || "file").replace(/[\s\/\\:*?"<>|]+/g, "_").slice(0, 100);
}

function guessImageExtension(mime) {
  if (!mime) return null;
  if (mime.includes("png")) return "png";
  if (mime.includes("jpeg") || mime.includes("jpg")) return "jpg";
  if (mime.includes("gif")) return "gif";
  if (mime.includes("webp")) return "webp";
  return null;
}

function blobToDataUrl(blob) {
  return new Promise((resolve) => {
    const reader = new FileReader();
    reader.onloadend = () => resolve(reader.result);
    reader.readAsDataURL(blob);
  });
}
