using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using UnitTests.Pages;

namespace UnitTests
{
    [TestClass]
    public class UnitTestPrime
    {
        readonly string url = "http://localhost/";

        private IWebDriver _driver;

        [TestMethod]
        public void LoginTest()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl(url);

            Login();
        }

        public void Login()
        {
            LoginPage page = new LoginPage(_driver);

            page.LnkLogin.Click();
            page.TxtUserName.SendKeys("admin");
            page.TxtPassword.SendKeys("password");
            page.BtnLogin.Submit();
        }
    }
}
