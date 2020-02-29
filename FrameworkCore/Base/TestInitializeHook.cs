using System;
using FrameworkCore.Config;
using FrameworkCore.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace FrameworkCore.Base
{
    public class TestInitializeHook : Steps
    {
        private readonly ParallelTestExecution _parallelTestExecution;

        public TestInitializeHook(ParallelTestExecution parallelTestExecution)
        {
            _parallelTestExecution = parallelTestExecution;
        }

        public void InitializeConfig()
        {
            const string config = "LOCAL-CHROME";

            ConfigReader.SetFrameworkSettings(config);
            LogHelpers.CreateLogFile();
            OpenBrowser(Settings.BrowserType);

            LogHelpers.WriteToLog($"[EVENT] :: Configuration Initialized :: {config}");
        }

        private void OpenBrowser(BrowserType browserType)
        {
            if (Settings.RemoteExecution)
                RunRemoteBrowser(browserType);
            else if (!Settings.RemoteExecution)
                RunLocalBrowser(browserType);
        }

        private void RunRemoteBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                #pragma warning disable CS0618, IDE0017

                case BrowserType.Firefox:
                    DesiredCapabilities geckoCapabilities = new DesiredCapabilities("firefox", Settings.RemoteBrowserVersion, new Platform(PlatformType.Any));
                    geckoCapabilities.AcceptInsecureCerts = true;
                    _parallelTestExecution.Driver = new RemoteWebDriver(new Uri($"http://{Settings.RemoteHost}:4444/wd/hub"), geckoCapabilities);
                    break;

                case BrowserType.Chrome:
                    DesiredCapabilities chromeCapabilities = new DesiredCapabilities("chrome", Settings.RemoteBrowserVersion, new Platform(PlatformType.Any));
                    chromeCapabilities.AcceptInsecureCerts = true;
                    _parallelTestExecution.Driver = new RemoteWebDriver(new Uri($"http://{Settings.RemoteHost}:4444/wd/hub"), chromeCapabilities);
                    break;

                default:
                    LogHelpers.WriteToLog($"[ERROR] :: Invalid Browser Type: {browserType}");
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, $"Invalid Browser Type: {browserType}");

                #pragma warning restore CS0618, IDE0017
            }
        }

        private void RunLocalBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Firefox:
                    FirefoxOptions optionsGecko = new FirefoxOptions();
                    optionsGecko.AddArguments("--width=1280", "--height=720", "--private");
                    _parallelTestExecution.Driver = new FirefoxDriver(optionsGecko);
                    break;

                case BrowserType.Chrome:
                    ChromeOptions optionsChrome = new ChromeOptions();
                    optionsChrome.AddArguments("--window-size=1280,720", "--incognito");
                    _parallelTestExecution.Driver = new ChromeDriver(optionsChrome);
                    break;

                default:
                    LogHelpers.WriteToLog($"[ERROR] :: Invalid Browser Type: {browserType}");
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, $"Invalid Browser Type: {browserType}");
            }
        }
    }
}