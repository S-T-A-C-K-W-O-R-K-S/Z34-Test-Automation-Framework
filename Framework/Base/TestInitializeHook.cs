using System;
using Framework.Config;
using Framework.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Framework.Base
{
    public abstract class TestInitializeHook : Base
    {
        public static void InitializeConfig()
        {
            ConfigReader.SetFrameworkSettings();
            LogHelpers.CreateLogFile();
            OpenBrowser(Settings.BrowserType);

            LogHelpers.WriteToLog("Framework Initialized");
        }

        private static void OpenBrowser(BrowserType browserType = BrowserType.Firefox)
        {
            switch (browserType)
            {
                case BrowserType.Firefox:
                    FirefoxOptions optionsGecko = new FirefoxOptions();
                    optionsGecko.AddArguments("--width=1280", "--height=720", "--private");
                    DriverContext.Driver = new FirefoxDriver(optionsGecko);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;

                case BrowserType.Chrome:
                    ChromeOptions optionsChrome = new ChromeOptions();
                    optionsChrome.AddArguments("--window-size=1280,720", "--incognito");
                    DriverContext.Driver = new ChromeDriver(optionsChrome);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;

                default:
                    LogHelpers.WriteToLog($"ERROR :: Invalid Browser Type: {browserType}");
                    throw new ArgumentOutOfRangeException(nameof(browserType), browserType, $"Invalid Browser Type: {browserType}");
            }
        }
    }
}