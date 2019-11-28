using System;
using FrameworkCore.Config;
using FrameworkCore.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
            const string config = "CHROME";

            ConfigReader.SetFrameworkSettings(config);
            LogHelpers.CreateLogFile();
            OpenBrowser(Settings.BrowserType);

            #pragma warning disable CS4014
            LogHelpers.WriteToLog($"[EVENT] :: Configuration Initialized :: {config}");
            #pragma warning restore CS4014
        }

        // TODO: Try Selenium Grid (RemoteWebDriver) :: https://github.com/SeleniumHQ/selenium/wiki/Selenium-Grid-4
        private void OpenBrowser(BrowserType browserType)
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
                    #pragma warning disable CS4014
                    LogHelpers.WriteToLog($"[ERROR] :: Invalid Browser Type: {browserType}");
                    #pragma warning restore CS4014

                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, $"Invalid Browser Type: {browserType}");
            }
        }
    }
}