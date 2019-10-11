using Framework.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using UnitTests.Pages;

namespace UnitTests
{
    [TestClass]
    public class InitialTest : Base
    {
        readonly string url = "http://localhost/";

        [TestMethod]
        public void ReachNewEmployeePage()
        {
            DriverContext.Driver = new FirefoxDriver();
            DriverContext.Driver.Navigate().GoToUrl(url);

            CurrentPage = GetInstance<LoginPage>();

            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().Login("admin", "password");

            CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();
            CurrentPage.As<EmployeePage>().ClickCreateNew();
        }
    }
}
