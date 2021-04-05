using System;
using System.IO;
using System.Threading.Tasks;
using FrameworkCore.Configuration;
using Microsoft.Extensions.Logging;
using PlaywrightSharp;

namespace FrameworkCore.Models
{
    public class PlaywrightDriver
    {
        private IBrowser Browser { get; set; }
        private IPage Page { get; set; }

        // TODO: Make This Pretty And Move It From Models

        public async Task<(IBrowser Browser, IPage Page)> InitialisePlaywrightDriver
            (string browserType, ILoggerFactory playwrightLogger = null, LaunchOptions launchOptions = null)
        {
            var playwright = await Playwright.CreateAsync(playwrightLogger, debug: "pw:api");

            launchOptions ??= new LaunchOptions {Headless = false, Devtools = true, SlowMo = 5};

            var browser = browserType.ToLower() switch
            {
                BrowserType.Chromium => await playwright.Chromium.LaunchAsync(launchOptions),
                BrowserType.Firefox => await playwright.Firefox.LaunchAsync(launchOptions),
                BrowserType.Webkit => await playwright.Webkit.LaunchAsync(launchOptions),
                _ => throw new ArgumentOutOfRangeException(nameof(browserType), browserType,
                    $"Invalid Browser Type: {browserType} (Expected: Chromium\\Firefox\\WebKit)")
            };

            var browserContextOptions = new BrowserContextOptions
            {
                RecordVideo = new RecordVideoOptions {Dir = Z34.TestResultsDir},
                RecordHar = new RecordHarOptions
                    {Path = Path.Combine(Z34.TestResultsDir, $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.har")}
            };

            var browserContext = await browser.NewContextAsync(browserContextOptions);

            Browser = browserContext.Browser;

            Page = await browserContext.NewPageAsync();

            return (Browser, Page);
        }
    }
}