using System;
using FrameworkCore.Config;
using FrameworkCore.Helpers;
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
            ConfigReader.SetFrameworkSettings("CHROME");
            LogHelpers.CreateLogFile();
            OpenBrowser(Settings.BrowserType);

            LogHelpers.WriteToLog("Framework Initialized");
        }

        private void OpenBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Firefox:
                    FirefoxOptions optionsGecko = new FirefoxOptions();
                    optionsGecko.AddArguments("--width=1280", "--height=720", "--private");
                    _parallelTestExecution.Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), optionsGecko);
                    break;

                case BrowserType.Chrome:
                    ChromeOptions optionsChrome = new ChromeOptions();
                    optionsChrome.AddArguments("--window-size=1280,720", "--incognito");
                    _parallelTestExecution.Driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), optionsChrome);
                    break;

                default:
                    LogHelpers.WriteToLog($"[ERROR] :: Invalid Browser Type: {browserType}");
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, $"Invalid Browser Type: {browserType}");
            }
        }
    }
}