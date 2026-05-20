(function () {
  // Only activate on URLs that contain "/faqs/"
  if (!/\/faqs\//.test(window.location.pathname)) return;

  // Try to find the main guide container.
  // These selectors are defensive; tweak if needed.
  function getGuideText() {
    const candidates = [
      '#faqtext',
      '.faqtext',
      '.faqbody',
      '.faqtext-content',
      'article'
    ];

    for (const sel of candidates) {
      const el = document.querySelector(sel);
      if (el) {
        // innerText preserves line breaks reasonably well
        return el.innerText.trim();
      }
    }

    // Fallback: whole body (last resort)
    return document.body.innerText.trim();
  }

  function createButton() {
    const btn = document.createElement('button');
    btn.textContent = 'Download Guide as .txt';

    Object.assign(btn.style, {
      position: 'fixed',
      bottom: '16px',
      right: '16px',
      zIndex: 99999,
      padding: '8px 12px',
      background: '#2c7be5',
      color: '#fff',
      border: 'none',
      borderRadius: '4px',
      fontSize: '14px',
      cursor: 'pointer',
      boxShadow: '0 2px 6px rgba(0,0,0,0.25)'
    });

    btn.addEventListener('mouseenter', () => {
      btn.style.background = '#1b5bb8';
    });
    btn.addEventListener('mouseleave', () => {
      btn.style.background = '#2c7be5';
    });

    btn.addEventListener('click', () => {
      const text = getGuideText();
      if (!text) {
        alert('Could not find guide text on this page.');
        return;
      }

      const blob = new Blob([text], { type: 'text/plain;charset=utf-8' });

      // Build a filename from the page title or URL
      const title = document.title
        .replace(/[\s\/\\:*?"<>|]+/g, '_')
        .slice(0, 80) || 'gamefaqs_guide';

      const a = document.createElement('a');
      a.href = URL.createObjectURL(blob);
      a.download = `${title}.txt`;
      document.body.appendChild(a);
      a.click();
      a.remove();
      URL.revokeObjectURL(a.href);
    });

    document.body.appendChild(btn);
  }

  // Wait a bit in case the guide content loads late
  if (document.readyState === 'complete' || document.readyState === 'interactive') {
    setTimeout(createButton, 500);
  } else {
    window.addEventListener('DOMContentLoaded', () => setTimeout(createButton, 500));
  }
})();
