using Framework.Config;
using Framework.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Framework.Base
{
    public abstract class TestInitializeHook : Base
    {
        public readonly BrowserType Browser;

        protected TestInitializeHook(BrowserType browser)
        {
            Browser = browser;
        }

        public void InitializeConfig()
        {
            ConfigReader.SetFrameworkSettings();
            LogHelpers.CreateLogFile();
            OpenBrowser(Browser);

            LogHelpers.WriteToLog("Framework Initialized");
        }

        private void OpenBrowser(BrowserType browserType = BrowserType.Firefox)
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

        public virtual void NavigateToAUT()
        {
            DriverContext.Browser.GoToURL(Settings.AUT);
            LogHelpers.WriteToLog($"Navigating To: {Settings.AUT}");
        }
    }
}