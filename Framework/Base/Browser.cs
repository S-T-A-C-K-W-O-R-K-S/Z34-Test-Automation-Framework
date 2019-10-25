using OpenQA.Selenium;

namespace Framework.Base
{
    public class Browser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Code Quality", "IDE0052: Remove Unread Private Members", Justification = "False-Positive")]
        private readonly IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public BrowserType Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822: Mark Members As Static", Justification = "False-Positive")]
        public void GoToUrl(string url)
        {
            DriverContext.Driver.Url = url;
        }
    }

    public enum BrowserType
    {
        Firefox,
        Chrome
    }
}