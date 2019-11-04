using Framework.Config;
using Framework.Extensions;
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
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }
    }
}