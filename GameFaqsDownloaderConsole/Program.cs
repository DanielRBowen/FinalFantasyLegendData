using System.Globalization;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Playwright;

Console.OutputEncoding = Encoding.UTF8;

AppOptions options;
AppLogger? logger = null;

try
{
		options = AppOptions.Parse(args);
}
catch (ArgumentException ex)
{
		Console.Error.WriteLine(ex.Message);
		Console.Error.WriteLine();
		AppOptions.PrintUsage();
		return 1;
}

if (options.ShowHelp)
{
		AppOptions.PrintUsage();
		return 0;
}

logger = AppLogger.Create(options.OutputDirectory);
Console.WriteLine($"Diagnostic log: {logger.LogFilePath}");
logger.Info("Program started.");
logger.Info($"Arguments: {FormatArguments(args)}");

var cancellationSource = new CancellationTokenSource();

Console.CancelKeyPress += (_, eventArgs) =>
{
		eventArgs.Cancel = true;
		logger?.Info("Cancellation requested from console.");
		cancellationSource.Cancel();
};

try
{
		var downloader = new GameFaqsDownloader(options, logger);
		var summary = await downloader.RunAsync(cancellationSource.Token);

		Console.WriteLine();
		Console.WriteLine(
				$"Finished. Saved {summary.FilesSaved} files from {summary.JobsProcessed} items across {summary.GamesProcessed} FAQ pages.");

		if (summary.SkippedJobs > 0)
		{
				Console.WriteLine($"Skipped {summary.SkippedJobs} items that could not be downloaded.");
		}

		Console.WriteLine($"Output folder: {summary.OutputDirectory}");
		return 0;
}
catch (OperationCanceledException)
{
		logger?.Info("Run cancelled.");
		Console.Error.WriteLine("Cancelled.");
		if (logger is not null)
		{
				Console.Error.WriteLine($"Diagnostic log: {logger.LogFilePath}");
		}
		return 1;
}
catch (Exception ex)
{
		logger?.Error("Fatal error.", ex);
		Console.Error.WriteLine(ex);
		if (logger is not null)
		{
				Console.Error.WriteLine($"Diagnostic log: {logger.LogFilePath}");
		}
		return 1;
}
finally
{
		logger?.Dispose();
}

static string FormatArguments(string[] values)
{
		return values.Length == 0
				? "<none>"
				: string.Join(" ", values.Select(value => value.Contains(' ') ? $"\"{value}\"" : value));
}

sealed class GameFaqsDownloader
{
		private static readonly Regex GuideOrMapIdRegex =
				new(@"/(?:faqs|map)/(?<id>\d+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

		private const string BrowserStealthScript =
				"""
				() => {
				  const defineValue = (target, property, value) => {
				    try {
				      Object.defineProperty(target, property, {
				        configurable: true,
				        enumerable: true,
				        get: () => value
				      });
				    } catch {
				    }
				  };

				  defineValue(navigator, 'webdriver', undefined);
				  defineValue(navigator, 'languages', ['en-US', 'en']);
				  defineValue(navigator, 'platform', 'Win32');
				  defineValue(navigator, 'hardwareConcurrency', 8);
				  defineValue(navigator, 'deviceMemory', 8);

				  const fakePlugins = [
				    { name: 'Chrome PDF Plugin', filename: 'internal-pdf-viewer' },
				    { name: 'Chrome PDF Viewer', filename: 'mhjfbmdgcfjbbpaeojofohoefgiehjai' },
				    { name: 'Native Client', filename: 'internal-nacl-plugin' }
				  ];
				  defineValue(navigator, 'plugins', fakePlugins);

				  if (!window.chrome) {
				    Object.defineProperty(window, 'chrome', {
				      configurable: true,
				      enumerable: true,
				      value: { runtime: {} }
				    });
				  }

				  const originalQuery = window.navigator.permissions?.query;
				  if (originalQuery) {
				    window.navigator.permissions.query = (parameters) => {
				      if (parameters?.name === 'notifications') {
				        return Promise.resolve({ state: Notification.permission });
				      }
				      return originalQuery.call(window.navigator.permissions, parameters);
				    };
				  }

				  const originalGetParameter = WebGLRenderingContext.prototype.getParameter;
				  WebGLRenderingContext.prototype.getParameter = function(parameter) {
				    if (parameter === 37445) {
				      return 'Intel Inc.';
				    }
				    if (parameter === 37446) {
				      return 'Intel Iris OpenGL Engine';
				    }
				    return originalGetParameter.call(this, parameter);
				  };
				}
				""";

		private readonly AppOptions _options;
		private readonly AppLogger _logger;

		public GameFaqsDownloader(AppOptions options, AppLogger logger)
		{
				_options = options;
				_logger = logger;
		}

		public async Task<DownloadSummary> RunAsync(CancellationToken cancellationToken)
		{
				Directory.CreateDirectory(_options.OutputDirectory);
				_logger.Info($"Output directory: {Path.GetFullPath(_options.OutputDirectory)}");
				_logger.Info(
						$"Options: Headless={_options.Headless}, BrowserChannel={_options.BrowserChannel ?? "<default>"}, ListOnly={_options.ListOnly}, Limit={_options.Limit?.ToString() ?? "<none>"}, Timeout={_options.WaitTimeoutSeconds}s");
				_logger.Info($"FAQ targets: {string.Join(", ", _options.FaqUrls)}");

				using var playwright = await Playwright.CreateAsync();
				_logger.Info("Playwright initialized.");
				await using var browserContext = await LaunchBrowserContextAsync(playwright);

				var catalogPage = browserContext.Pages.FirstOrDefault() ?? await browserContext.NewPageAsync();
				var workPage = browserContext.Pages.Skip(1).FirstOrDefault() ?? await browserContext.NewPageAsync();

				ConfigurePage(catalogPage, "catalog");
				ConfigurePage(workPage, "work");

				var summary = new DownloadSummary
				{
						OutputDirectory = Path.GetFullPath(_options.OutputDirectory)
				};

				foreach (var faqUrl in _options.FaqUrls)
				{
						cancellationToken.ThrowIfCancellationRequested();

						Console.WriteLine();
						Console.WriteLine($"Scanning {faqUrl}");
						_logger.Info($"Scanning FAQ page: {faqUrl}");

						string gameName;
						List<DownloadJob> jobs;

						try
						{
								await NavigateWithChallengeHandlingAsync(
										catalogPage,
										faqUrl,
										"FAQ listings",
										() => PageHasAnySelectorAsync(catalogPage, "a[href*='/faqs/'], a[href*='/map/'], .pod"),
										cancellationToken);

								var pageState = await CapturePageStateAsync(catalogPage);
								_logger.Info(
										$"FAQ page ready. Url={pageState.Url} Title={pageState.Title} ReadyState={pageState.ReadyState} TextSnippet={pageState.BodySnippet}");

								gameName = await ExtractGameNameAsync(catalogPage, faqUrl);
								_logger.Info($"Extracted game name: {gameName}");

								jobs = await ExtractJobsAsync(catalogPage);
								_logger.Info($"Extracted {jobs.Count} eligible jobs from {faqUrl}.");

								foreach (var job in jobs.Take(5))
								{
										_logger.Info($"Job sample: Section={job.SectionType}, Kind={job.Kind}, Title={job.Title}, Url={job.Url}");
								}
						}
						catch (Exception ex) when (ex is not OperationCanceledException)
						{
								_logger.Error($"Failed while scanning FAQ page: {faqUrl}", ex);
								await SaveDiagnosticSnapshotAsync(catalogPage, "faq-scan-failure");
								throw;
						}

						if (_options.Limit is > 0)
						{
								jobs = jobs.Take(_options.Limit.Value).ToList();
								_logger.Info($"Applied limit {_options.Limit.Value}; {jobs.Count} jobs remain for {gameName}.");
						}

						Console.WriteLine($"Found {jobs.Count} eligible items for {gameName}.");

						if (jobs.Count == 0)
						{
								_logger.Info($"No eligible jobs found for {gameName}.");
								summary.GamesProcessed++;
								continue;
						}

						if (_options.ListOnly)
						{
								foreach (var job in jobs)
								{
										Console.WriteLine($"[{job.SectionType}] {job.Kind} :: {job.Title} :: {job.Url}");
								}

								summary.GamesProcessed++;
								summary.JobsProcessed += jobs.Count;
								continue;
						}

						var gameDirectory = Path.Combine(_options.OutputDirectory, SanitizePathSegment(gameName));
						Directory.CreateDirectory(gameDirectory);
						_logger.Info($"Game directory: {gameDirectory}");

						foreach (var job in jobs)
						{
								cancellationToken.ThrowIfCancellationRequested();

								Console.WriteLine($"Downloading {job.Kind}: {job.Title}");
								_logger.Info($"Downloading {job.Kind}: {job.Title} ({job.Url})");

								try
								{
										var saved = job.Kind.Equals("map", StringComparison.OrdinalIgnoreCase)
												? await DownloadMapAsync(workPage, gameDirectory, job, cancellationToken)
												: await DownloadGuideAsync(workPage, gameDirectory, job, cancellationToken);

										if (saved)
										{
												summary.FilesSaved++;
												summary.JobsProcessed++;
												_logger.Info($"Saved {job.Kind}: {job.Title}");
										}
										else
										{
												summary.SkippedJobs++;
												_logger.Info($"Skipped without exception: {job.Url}");
										}
								}
								catch (Exception ex) when (ex is not OperationCanceledException)
								{
										summary.SkippedJobs++;
										_logger.Error($"Job failed: {job.Url}", ex);
										Console.Error.WriteLine($"  Skipped {job.Url}: {ex.Message}");
								}
						}

						summary.GamesProcessed++;
				}

				return summary;
		}

		private async Task<IBrowserContext> LaunchBrowserContextAsync(IPlaywright playwright)
		{
				var profileDirectory = Path.Combine(
						Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
						"GameFaqsDownloaderConsole",
						"playwright-profile");

				Directory.CreateDirectory(profileDirectory);

				var channelsToTry = new List<string?>();

				if (!string.IsNullOrWhiteSpace(_options.BrowserChannel))
				{
						channelsToTry.Add(_options.BrowserChannel);
				}

				channelsToTry.Add(null);

				List<Exception>? launchErrors = null;

				foreach (var channel in channelsToTry.Distinct(StringComparer.OrdinalIgnoreCase))
				{
						try
						{
								Console.WriteLine(
										channel is null
												? "Launching browser context with Playwright-managed Chromium."
												: $"Launching browser context with channel '{channel}'.");
								_logger.Info(
										channel is null
												? "Launching browser context with Playwright-managed Chromium."
												: $"Launching browser context with channel '{channel}'.");

								var context = await playwright.Chromium.LaunchPersistentContextAsync(
										profileDirectory,
										new BrowserTypeLaunchPersistentContextOptions
										{
												Headless = _options.Headless,
												Channel = channel,
												Args = new[] { "--disable-blink-features=AutomationControlled" },
												IgnoreDefaultArgs = new[] { "--enable-automation" },
												ViewportSize = new ViewportSize { Width = 1440, Height = 2200 },
												UserAgent = BrowserUserAgent.Value,
												IgnoreHTTPSErrors = true,
												Locale = "en-US",
												ColorScheme = ColorScheme.Light,
												ExtraHTTPHeaders = new Dictionary<string, string>
												{
														["Accept-Language"] = "en-US,en;q=0.9",
														["Upgrade-Insecure-Requests"] = "1"
												}
										});

								await context.AddInitScriptAsync(BrowserStealthScript);
								_logger.Info("Applied browser stealth script.");
								return context;
						}
						catch (Exception ex)
						{
								launchErrors ??= new List<Exception>();
								launchErrors.Add(ex);
								_logger.Error($"Browser launch failed for channel '{channel ?? "<playwright>"}'.", ex);
						}
				}

				var installPath = Path.Combine(AppContext.BaseDirectory, "playwright.ps1");

				throw new InvalidOperationException(
						$"Unable to launch a usable browser. If Microsoft Edge is unavailable, build the project and run 'pwsh \"{installPath}\" install chromium'.",
						launchErrors is null ? null : new AggregateException(launchErrors));
		}

		private void ConfigurePage(IPage page, string pageName)
		{
				page.SetDefaultNavigationTimeout(180_000);
				page.SetDefaultTimeout(180_000);

				page.Console += (_, message) =>
				{
						if (message.Type is "error" or "warning")
						{
								_logger.Info($"[{pageName} console {message.Type}] {message.Text}");
						}
				};

				page.PageError += (_, message) =>
				{
						_logger.Info($"[{pageName} page error] {message}");
				};
		}

		private async Task NavigateWithChallengeHandlingAsync(
				IPage page,
				string url,
				string description,
				Func<Task<bool>> readinessCheck,
				CancellationToken cancellationToken)
		{
				await page.BringToFrontAsync();
				await page.GotoAsync(url, new PageGotoOptions { WaitUntil = WaitUntilState.DOMContentLoaded });
				await page.BringToFrontAsync();
				_logger.Info($"Navigated to {url} for {description}. Current page URL: {page.Url}");

				var deadline = DateTime.UtcNow.AddSeconds(_options.WaitTimeoutSeconds);
				var challengeNotified = false;

				while (DateTime.UtcNow < deadline)
				{
						cancellationToken.ThrowIfCancellationRequested();

						if (await readinessCheck())
						{
								await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
								_logger.Info($"Readiness check passed for {description} at {page.Url}.");
								return;
						}

						if (await IsChallengePageAsync(page) && !challengeNotified)
						{
								challengeNotified = true;
								await page.BringToFrontAsync();
								_logger.Info($"Cloudflare challenge detected while waiting for {description} at {page.Url}.");
								Console.WriteLine(
										"Cloudflare challenge detected. If a browser window opened, complete the check there and the program will continue automatically.");
						}

						await page.WaitForTimeoutAsync(1000);
				}

				var pageState = await CapturePageStateAsync(page);
				_logger.Info(
						$"Timed out waiting for {description}. Url={url} CurrentUrl={pageState.Url} Title={pageState.Title} ReadyState={pageState.ReadyState} TextSnippet={pageState.BodySnippet}");
				throw new InvalidOperationException(
						challengeNotified
								? $"Timed out waiting for {description} on {url}. GameFAQs is still presenting a Cloudflare challenge. Complete it in the visible browser window, then rerun the program."
								: $"Timed out waiting for {description} on {url}.");
		}

		private async Task<PageStatePayload> CapturePageStateAsync(IPage page)
		{
				return await page.EvaluateAsync<PageStatePayload>(
						"""
						() => ({
							url: location.href,
							title: document.title || '',
							readyState: document.readyState || '',
							bodySnippet: (document.body?.innerText || '').replace(/\s+/g, ' ').trim().slice(0, 240)
						})
						""");
		}

		private async Task SaveDiagnosticSnapshotAsync(IPage page, string prefix)
		{
				var stamp = DateTime.Now.ToString("yyyyMMdd-HHmmss");
				var safePrefix = SanitizePathSegment(prefix).Replace(' ', '-');
				var htmlPath = Path.Combine(_logger.LogDirectory, $"{stamp}-{safePrefix}.html");
				var screenshotPath = Path.Combine(_logger.LogDirectory, $"{stamp}-{safePrefix}.png");

				try
				{
						var content = await page.ContentAsync();
						await File.WriteAllTextAsync(htmlPath, content, new UTF8Encoding(false));
						_logger.Info($"Saved HTML snapshot: {htmlPath}");
				}
				catch (Exception ex)
				{
						_logger.Error("Failed to save HTML snapshot.", ex);
				}

				try
				{
						await page.ScreenshotAsync(new PageScreenshotOptions
						{
								Path = screenshotPath,
								FullPage = true
						});
						_logger.Info($"Saved screenshot snapshot: {screenshotPath}");
				}
				catch (Exception ex)
				{
						_logger.Error("Failed to save screenshot snapshot.", ex);
				}
		}

		private static async Task<bool> IsChallengePageAsync(IPage page)
		{
				return await page.EvaluateAsync<bool>(
						"""
						() => {
							const title = (document.title || '').toLowerCase();
							const text = (document.body?.innerText || '').toLowerCase();
							return title.includes('just a moment')
								|| text.includes('enable javascript and cookies to continue')
								|| text.includes('verify you are human');
						}
						""");
		}

		private static async Task<bool> PageHasAnySelectorAsync(IPage page, string selectorList)
		{
				return await page.EvaluateAsync<bool>(
						"""
						selectorList => Array.from(selectorList.split(','))
							.map(selector => selector.trim())
							.some(selector => selector.length > 0 && document.querySelector(selector))
						""",
						selectorList);
		}

		private static async Task<string> ExtractGameNameAsync(IPage page, string fallbackUrl)
		{
				var rawName = await page.EvaluateAsync<string?>(
						"""
						() => {
							const heading = document.querySelector('h1')?.textContent?.trim();
							if (heading) {
								return heading;
							}

							const title = document.title || '';
							const match = title.match(/^(.*?)\s+FAQs/i);
							return match ? match[1].trim() : title.trim();
						}
						""");

				if (!string.IsNullOrWhiteSpace(rawName))
				{
						return rawName;
				}

				return new Uri(fallbackUrl).Segments.Last().Trim('/');
		}

		private static async Task<List<DownloadJob>> ExtractJobsAsync(IPage page)
		{
				var jobPayloads = await page.EvaluateAsync<List<JobPayload?>?>(
						"""
						() => {
							const normalize = (value) => (value || '').replace(/\s+/g, ' ').trim();
							const classifyHeading = (value) => {
								const text = normalize(value).toLowerCase();
								if (!text) return null;
								if (text.includes('foreign language')) return 'skip';
								if (text.includes('patch codes') || text === 'codes' || text.includes('codebreaker') || text.includes('action replay')) return 'skip';
								if (text.includes('full game guides')) return 'full';
								if (text.includes('in-depth guides')) return 'indepth';
								if (text.includes('maps and charts')) return 'maps';
								return null;
							};

							const toAbsolute = (href) => {
								try {
									return new URL(href, location.href).href;
								} catch {
									return null;
								}
							};

							const seen = new Set();
							const jobs = [];

							const addLinksFromContainer = (container, sectionType) => {
								if (!container || !sectionType || sectionType === 'skip') {
									return;
								}

								for (const anchor of container.querySelectorAll("a[href*='/faqs/'], a[href*='/map/']")) {
									const url = toAbsolute(anchor.getAttribute('href'));
									if (!url || seen.has(url)) {
										continue;
									}

									const title = normalize(anchor.textContent) || normalize(anchor.getAttribute('aria-label'));
									if (!title) {
										continue;
									}

									const kind = /\/map\//i.test(url) ? 'map' : /\/faqs\//i.test(url) ? 'guide' : null;
									if (!kind) {
										continue;
									}

									seen.add(url);
									jobs.push({
										kind,
										sectionType,
										title,
										url
									});
								}
							};

							for (const pod of document.querySelectorAll('.pod')) {
								const headingText = normalize(pod.querySelector('.head h1, .head h2, .head h3, .head h4, h1, h2, h3, h4')?.textContent);
								addLinksFromContainer(pod, classifyHeading(headingText));
							}

							if (jobs.length > 0) {
								return jobs;
							}

							for (const heading of document.querySelectorAll('.head h1, .head h2, .head h3, .head h4, h1, h2, h3, h4, h5')) {
								const sectionType = classifyHeading(heading.textContent);
								if (!sectionType || sectionType === 'skip') {
									continue;
								}

								const container = heading.closest('.pod, section, article, div') || heading.parentElement;
								addLinksFromContainer(container, sectionType);
							}

							return jobs;
						}
						""");

				return (jobPayloads ?? new List<JobPayload?>())
						.OfType<JobPayload>()
						.Where(payload =>
								!string.IsNullOrWhiteSpace(payload.Kind)
								&& !string.IsNullOrWhiteSpace(payload.SectionType)
								&& !string.IsNullOrWhiteSpace(payload.Title)
								&& !string.IsNullOrWhiteSpace(payload.Url))
						.GroupBy(payload => payload.Url!, StringComparer.OrdinalIgnoreCase)
						.Select(group =>
						{
								var payload = group.First();
								return new DownloadJob(
										payload.Kind!,
										payload.SectionType!,
										payload.Title!,
										payload.Url!);
						})
						.ToList();
		}

		private async Task<bool> DownloadGuideAsync(
				IPage page,
				string gameDirectory,
				DownloadJob job,
				CancellationToken cancellationToken)
		{
				await NavigateWithChallengeHandlingAsync(
						page,
						job.Url,
						"guide content",
						() => PageHasAnySelectorAsync(page, "#faqtext, .faqtext, .faqbody, article, main"),
						cancellationToken);

				var guide = await page.EvaluateAsync<GuidePayload?>(
						"""
						() => {
							const normalize = (value) => (value || '').replace(/\r\n/g, '\n').replace(/\s+\n/g, '\n').trim();
							const title = (document.querySelector('h1')?.textContent || document.title || 'Guide').trim();

							const textNode = document.querySelector('#faqtext, pre#faqtext, .faqtext pre, .faqbody pre, .ffaq pre');
							if (textNode) {
								return {
									format: 'txt',
									title,
									content: normalize(textNode.innerText)
								};
							}

							const container = document.querySelector('article .body, article .content, article, .faqbody, main article, main');
							if (!container) {
								return null;
							}

							const clone = container.cloneNode(true);
							clone.querySelectorAll('script, style, noscript, button, form, iframe').forEach(node => node.remove());
							clone.querySelectorAll('[href]').forEach(node => {
								const href = node.getAttribute('href');
								if (href) {
									node.setAttribute('href', new URL(href, location.href).href);
								}
							});
							clone.querySelectorAll('[src]').forEach(node => {
								const src = node.getAttribute('src');
								if (src) {
									node.setAttribute('src', new URL(src, location.href).href);
								}
							});

							const richContent = clone.querySelector('p, h1, h2, h3, h4, h5, ul, ol, table, blockquote, img, a');
							if (richContent) {
								return {
									format: 'html',
									title,
									content: clone.innerHTML.trim()
								};
							}

							return {
								format: 'txt',
								title,
								content: normalize(clone.innerText)
							};
						}
						""");

				if (guide is null || string.IsNullOrWhiteSpace(guide.Content))
				{
						return false;
				}

				var sectionDirectory = Path.Combine(gameDirectory, job.SectionDirectoryName);
				Directory.CreateDirectory(sectionDirectory);

				var baseName = BuildBaseFileName(job.Url, job.Title);

				if (guide.Format.Equals("html", StringComparison.OrdinalIgnoreCase))
				{
						var path = Path.Combine(sectionDirectory, baseName + ".html");
						var html = BuildGuideHtmlDocument(guide.Title ?? job.Title, job.Url, guide.Content);
						await File.WriteAllTextAsync(path, html, new UTF8Encoding(false), cancellationToken);
						return true;
				}

				var textPath = Path.Combine(sectionDirectory, baseName + ".txt");
				await File.WriteAllTextAsync(
						textPath,
						NormalizeLineEndings(guide.Content),
						new UTF8Encoding(false),
						cancellationToken);
				return true;
		}

		private async Task<bool> DownloadMapAsync(
				IPage page,
				string gameDirectory,
				DownloadJob job,
				CancellationToken cancellationToken)
		{
				await NavigateWithChallengeHandlingAsync(
						page,
						job.Url,
						"map content",
						() => PageHasAnySelectorAsync(page, "meta[property='og:image'], .map img, article img, main img, img"),
						cancellationToken);

				var mapImage = await page.EvaluateAsync<MapImagePayload?>(
						"""
						() => {
							const title = (document.querySelector('h1')?.textContent || document.title || 'Map').trim();
							const toAbsolute = (value) => {
								if (!value) {
									return null;
								}

								try {
									return new URL(value, location.href).href;
								} catch {
									return null;
								}
							};

							const imageCandidates = Array.from(document.querySelectorAll('.map img, article img, main img, img'))
								.map(image => ({
									url: toAbsolute(image.currentSrc || image.getAttribute('src')),
									area: (image.naturalWidth || image.width || 0) * (image.naturalHeight || image.height || 0)
								}))
								.filter(image => image.url && !image.url.startsWith('data:'))
								.sort((left, right) => right.area - left.area);

							const ogImage = toAbsolute(document.querySelector("meta[property='og:image']")?.getAttribute('content'));
							const imageUrl = imageCandidates[0]?.url || ogImage;

							return imageUrl
								? {
										title,
										imageUrl
									}
								: null;
						}
						""");

				if (mapImage is null || string.IsNullOrWhiteSpace(mapImage.ImageUrl))
				{
						return false;
				}

				var binary = await page.EvaluateAsync<BinaryDownloadPayload?>(
						"""
						async (url) => {
							const response = await fetch(url, { credentials: 'include' });
							if (!response.ok) {
								return {
									ok: false,
									statusCode: response.status,
									contentType: response.headers.get('content-type') || '',
									base64: ''
								};
							}

							const buffer = await response.arrayBuffer();
							const bytes = new Uint8Array(buffer);
							let binary = '';
							const chunkSize = 0x8000;

							for (let index = 0; index < bytes.length; index += chunkSize) {
								binary += String.fromCharCode(...bytes.subarray(index, index + chunkSize));
							}

							return {
								ok: true,
								statusCode: response.status,
								contentType: response.headers.get('content-type') || '',
								base64: btoa(binary)
							};
						}
						""",
						mapImage.ImageUrl);

				if (binary is null || !binary.Ok || string.IsNullOrWhiteSpace(binary.Base64))
				{
						return false;
				}

				var sectionDirectory = Path.Combine(gameDirectory, job.SectionDirectoryName);
				Directory.CreateDirectory(sectionDirectory);

				var extension = GuessFileExtension(binary.ContentType, mapImage.ImageUrl);
				var filePath = Path.Combine(sectionDirectory, BuildBaseFileName(job.Url, job.Title) + extension);
				var bytes = Convert.FromBase64String(binary.Base64);

				await File.WriteAllBytesAsync(filePath, bytes, cancellationToken);
				return true;
		}

		private static string BuildBaseFileName(string url, string title)
		{
				var id = GuideOrMapIdRegex.Match(url).Groups["id"].Value;
				var safeTitle = SanitizePathSegment(title);
				return string.IsNullOrWhiteSpace(id) ? safeTitle : $"{id}_{safeTitle}";
		}

		private static string SanitizePathSegment(string value)
		{
				var invalidChars = Path.GetInvalidFileNameChars();
				var cleaned = new string(value.Select(ch => invalidChars.Contains(ch) ? '_' : ch).ToArray());
				cleaned = Regex.Replace(cleaned, @"\s+", " ").Trim();
				cleaned = cleaned.Replace('.', '_');
				return string.IsNullOrWhiteSpace(cleaned) ? "untitled" : cleaned;
		}

		private static string NormalizeLineEndings(string value)
		{
				return value.Replace("\r\n", "\n").Replace("\r", "\n");
		}

		private static string GuessFileExtension(string? contentType, string imageUrl)
		{
				var normalizedContentType = (contentType ?? string.Empty).ToLowerInvariant();
				if (normalizedContentType.Contains("png"))
				{
						return ".png";
				}

				if (normalizedContentType.Contains("jpeg") || normalizedContentType.Contains("jpg"))
				{
						return ".jpg";
				}

				if (normalizedContentType.Contains("gif"))
				{
						return ".gif";
				}

				if (normalizedContentType.Contains("webp"))
				{
						return ".webp";
				}

				var uri = new Uri(imageUrl);
				var extension = Path.GetExtension(uri.AbsolutePath);
				return string.IsNullOrWhiteSpace(extension) ? ".png" : extension;
		}

		private static string BuildGuideHtmlDocument(string title, string sourceUrl, string bodyHtml)
		{
				var encodedTitle = WebUtility.HtmlEncode(title);
				var encodedSourceUrl = WebUtility.HtmlEncode(sourceUrl);

				return $$"""
				<!DOCTYPE html>
				<html lang="en">
				<head>
					<meta charset="utf-8">
					<meta name="viewport" content="width=device-width, initial-scale=1">
					<title>{{encodedTitle}}</title>
					<style>
						:root {
							color-scheme: light;
							font-family: Georgia, 'Times New Roman', serif;
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
					</style>
				</head>
				<body>
					<header>
						<h1>{{encodedTitle}}</h1>
						<p>Source: <a href="{{encodedSourceUrl}}">{{encodedSourceUrl}}</a></p>
					</header>
					<main>
						{{bodyHtml}}
					</main>
				</body>
				</html>
				""";
		}
}

sealed class AppOptions
{
		public static readonly IReadOnlyList<string> DefaultFaqUrls = new[]
		{
				"https://gamefaqs.gamespot.com/gameboy/563273-the-final-fantasy-legend/faqs",
				"https://gamefaqs.gamespot.com/gameboy/585710-final-fantasy-legend-ii/faqs",
				"https://gamefaqs.gamespot.com/gameboy/563274-final-fantasy-legend-iii/faqs"
		};

		public string OutputDirectory { get; private init; } = Path.Combine(Environment.CurrentDirectory, "downloads");

		public string? BrowserChannel { get; private init; } = OperatingSystem.IsWindows() ? "msedge" : null;

		public bool Headless { get; private init; }

		public bool ListOnly { get; private init; }

		public int? Limit { get; private init; }

		public bool ShowHelp { get; private init; }

		public int WaitTimeoutSeconds { get; private init; } = 180;

		public IReadOnlyList<string> FaqUrls { get; private init; } = DefaultFaqUrls;

		public static AppOptions Parse(string[] args)
		{
				var outputDirectory = Path.Combine(Environment.CurrentDirectory, "downloads");
				string? browserChannel = OperatingSystem.IsWindows() ? "msedge" : null;
				var headless = false;
				var listOnly = false;
				int? limit = null;
				var showHelp = false;
				var timeoutSeconds = 180;
				var urls = new List<string>();

				for (var index = 0; index < args.Length; index++)
				{
						var argument = args[index];

						switch (argument)
						{
								case "--output":
								case "-o":
										outputDirectory = GetRequiredValue(args, ++index, argument);
										break;

								case "--browser":
										browserChannel = GetRequiredValue(args, ++index, argument);
										break;

								case "--headless":
										headless = true;
										break;

								case "--list-only":
										listOnly = true;
										break;

								case "--limit":
										limit = ParsePositiveInteger(GetRequiredValue(args, ++index, argument), argument);
										break;

								case "--timeout":
										timeoutSeconds = ParsePositiveInteger(GetRequiredValue(args, ++index, argument), argument);
										break;

								case "--help":
								case "-h":
								case "/?":
										showHelp = true;
										break;

								default:
										if (argument.StartsWith("--", StringComparison.Ordinal))
										{
												throw new ArgumentException($"Unknown option: {argument}");
										}

										urls.Add(argument);
										break;
						}
				}

				if (urls.Count == 0)
				{
						urls.AddRange(DefaultFaqUrls);
				}

				return new AppOptions
				{
						OutputDirectory = Path.GetFullPath(outputDirectory),
						BrowserChannel = string.IsNullOrWhiteSpace(browserChannel) ? null : browserChannel,
						Headless = headless,
						ListOnly = listOnly,
						Limit = limit,
						ShowHelp = showHelp,
						WaitTimeoutSeconds = timeoutSeconds,
						FaqUrls = urls
				};
		}

		public static void PrintUsage()
		{
				Console.WriteLine("GameFAQs FFL downloader for .NET 10");
				Console.WriteLine();
				Console.WriteLine("Usage:");
				Console.WriteLine("  dotnet run -- [options] [faq-url ...]");
				Console.WriteLine();
				Console.WriteLine("Options:");
				Console.WriteLine("  --output, -o <dir>   Output folder. Defaults to ./downloads");
				Console.WriteLine("  --browser <channel>  Browser channel, for example msedge, chrome, chromium");
				Console.WriteLine("  --headless           Run without opening a visible browser window");
				Console.WriteLine("  --list-only          Only list discovered jobs without downloading them");
				Console.WriteLine("  --limit <count>      Process only the first N jobs from each FAQ page");
				Console.WriteLine("  --timeout <seconds>  Maximum wait time for Cloudflare and page content. Default 180");
				Console.WriteLine("  --help, -h           Show this help text");
				Console.WriteLine();
				Console.WriteLine("If no FAQ URLs are supplied, the program downloads from these pages:");

				foreach (var url in DefaultFaqUrls)
				{
						Console.WriteLine($"  {url}");
				}

				Console.WriteLine();
				Console.WriteLine("Headless mode is supported, but the default visible browser is more reliable against GameFAQs' Cloudflare challenge.");
		}

		private static string GetRequiredValue(string[] args, int index, string optionName)
		{
				if (index >= args.Length)
				{
						throw new ArgumentException($"Missing value for {optionName}");
				}

				return args[index];
		}

		private static int ParsePositiveInteger(string value, string optionName)
		{
				if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var parsed) || parsed <= 0)
				{
						throw new ArgumentException($"{optionName} requires a positive integer.");
				}

				return parsed;
		}
}

sealed record DownloadJob(string Kind, string SectionType, string Title, string Url)
{
		public string SectionDirectoryName => SectionType switch
		{
				"full" => "Full Game Guides",
				"indepth" => "In-Depth Guides",
				"maps" => "Maps and Charts",
				_ => "Other"
		};
}

sealed class DownloadSummary
{
		public string OutputDirectory { get; set; } = string.Empty;

		public int GamesProcessed { get; set; }

		public int JobsProcessed { get; set; }

		public int FilesSaved { get; set; }

		public int SkippedJobs { get; set; }
}

sealed class AppLogger : IDisposable
{
		private readonly object _sync = new();
		private readonly StreamWriter _writer;

		private AppLogger(string logFilePath, string logDirectory)
		{
				LogFilePath = logFilePath;
				LogDirectory = logDirectory;
				_writer = new StreamWriter(File.Open(logFilePath, FileMode.Create, FileAccess.Write, FileShare.Read))
				{
						AutoFlush = true
				};
		}

		public string LogFilePath { get; }

		public string LogDirectory { get; }

		public static AppLogger Create(string outputDirectory)
		{
				var logDirectory = Path.Combine(Path.GetFullPath(outputDirectory), "_logs");
				Directory.CreateDirectory(logDirectory);
				var logFilePath = Path.Combine(logDirectory, $"run-{DateTime.Now:yyyyMMdd-HHmmss}.log");
				return new AppLogger(logFilePath, logDirectory);
		}

		public void Info(string message)
		{
				Write("INFO", message);
		}

		public void Error(string message, Exception ex)
		{
				Write("ERROR", $"{message}{Environment.NewLine}{ex}");
		}

		public void Dispose()
		{
				lock (_sync)
				{
						_writer.Dispose();
				}
		}

		private void Write(string level, string message)
		{
				var line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} [{level}] {message}";

				lock (_sync)
				{
						_writer.WriteLine(line);
				}
		}
}

sealed class JobPayload
{
		public string? Kind { get; set; }

		public string? SectionType { get; set; }

		public string? Title { get; set; }

		public string? Url { get; set; }
}

sealed class PageStatePayload
{
		public string Url { get; set; } = string.Empty;

		public string Title { get; set; } = string.Empty;

		public string ReadyState { get; set; } = string.Empty;

		public string BodySnippet { get; set; } = string.Empty;
}

sealed class GuidePayload
{
		public string Format { get; set; } = "txt";

		public string? Title { get; set; }

		public string Content { get; set; } = string.Empty;
}

sealed class MapImagePayload
{
		public string? Title { get; set; }

		public string? ImageUrl { get; set; }
}

sealed class BinaryDownloadPayload
{
		public bool Ok { get; set; }

		public int StatusCode { get; set; }

		public string? ContentType { get; set; }

		public string? Base64 { get; set; }
}

static class BrowserUserAgent
{
		public static string Value { get; } =
				"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/136.0.0.0 Safari/537.36";
}
