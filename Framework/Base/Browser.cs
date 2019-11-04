using System.Diagnostics.CodeAnalysis;
using OpenQA.Selenium;

namespace Framework.Base
{
    public class Browser
    {
        [SuppressMessage("Code Quality", "IDE0052: Remove Unread Private Members", Justification = "False-Positive")]
        private readonly IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public BrowserType Type { get; set; }

        [SuppressMessage("Performance", "CA1822: Mark Members As Static", Justification = "False-Positive")]
        public void GoToURL(string url)
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