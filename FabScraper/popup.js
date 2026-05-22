document.getElementById('start-btn').addEventListener('click', async () => {
  const btn = document.getElementById('start-btn');
  const statusDiv = document.getElementById('status');
  
  btn.disabled = true;
  statusDiv.innerText = "Initializing scan...";

  // Find the active tab
  const [tab] = await chrome.tabs.query({ active: true, currentWindow: true });
  
  if (!tab?.url?.includes("fab.com/library")) {
    statusDiv.innerText = "Open https://www.fab.com/library first.";
    btn.disabled = false;
    return;
  }

  // Tell content.js to start the progressive scroll loop
  chrome.tabs.sendMessage(tab.id, { action: "START_SCRAPE" }, response => {
    if (chrome.runtime.lastError || !response?.ok) {
      statusDiv.innerText = "Could not start scraper on this tab. Refresh the page and try again.";
      btn.disabled = false;
    }
  });
});

// Listen for live item counts from the content script
chrome.runtime.onMessage.addListener((message) => {
  const statusDiv = document.getElementById('status');
  const btn = document.getElementById('start-btn');

  if (message.action === "SCRAPE_PROGRESS") {
    if (message.stage === "details") {
      statusDiv.innerText = `Enriching asset details ${message.detailProgress}...`;
    } else {
      statusDiv.innerText = `Scraped ${message.count} assets so far...`;
    }
  } else if (message.action === "SCRAPE_LOG") {
    statusDiv.innerText = message.entry?.message || statusDiv.innerText;
  } else if (message.action === "SCRAPE_COMPLETE") {
    statusDiv.innerText = message.message || `Finished! Exported ${message.count} assets.`;
    btn.disabled = false;
  }
});