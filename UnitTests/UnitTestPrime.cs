using Framework.Base;
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

        [TestMethod]
        public void LoginTest()
        {
            DriverContext.Driver = new FirefoxDriver();
            DriverContext.Driver.Navigate().GoToUrl(url);

            Login();
        }

        public void Login()
        {
            LoginPage page = new LoginPage();

            page.LnkLogin.Click();
            page.TxtUserName.SendKeys("admin");
            page.TxtPassword.SendKeys("password");
            page.BtnLogin.Submit();
        }
    }
}
