using Framework.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using UnitTests.Pages;

namespace UnitTests
{
    [TestClass]
    public class UnitTestPrime : Base
    {
        readonly string url = "http://localhost/";

        [TestMethod]
        public void PrimeTest()
        {
            DriverContext.Driver = new FirefoxDriver();
            DriverContext.Driver.Navigate().GoToUrl(url);

            LoginPage loginPage = new LoginPage();

            loginPage.ClickLoginLink();
            loginPage.Login("admin", "password");

            CurrentPage = loginPage.ClickEmployeeList();
            ((EmployeePage)CurrentPage).ClickCreateNew();
        }
    }
}
