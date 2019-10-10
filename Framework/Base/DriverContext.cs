using OpenQA.Selenium;

namespace Framework.Base
{
    public static class DriverContext
    {
        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get { return _driver; }
            set { _driver = value; }
        }
    }
}
