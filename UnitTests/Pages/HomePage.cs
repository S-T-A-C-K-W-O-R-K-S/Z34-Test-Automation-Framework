using Framework.Base;
using Framework.Extensions;
using OpenQA.Selenium;

namespace UnitTests.Pages
{
    internal class HomePage : BasePage
    {
        private static IWebElement LinkLogIn => DriverContext.Driver.FindElement(By.LinkText("Login"));
        private static IWebElement LinkEmployeeList => DriverContext.Driver.FindElement(By.LinkText("Employee List"));
        private static IWebElement LinkLoggedInUser => DriverContext.Driver.FindElement(By.XPath("//a[@title='Manage']"));
        private static IWebElement LinkLogOff => DriverContext.Driver.FindElement(By.LinkText("Log Off"));

        internal void AssertLoginLinkPresence() => LinkLogIn.AssertElementPresent();

        public LoginPage ClickLogIn()
        {
            LinkLogIn.Click();
            DriverContext.Driver.WaitForPageLoaded();
            return GetInstance<LoginPage>();
        }

        internal string GetLoggedInUser() => LinkLoggedInUser.GetLinkText();

        public EmployeeListPage ClickEmployeeList()
        {
            LinkEmployeeList.Click();
            DriverContext.Driver.WaitForPageLoaded();
            return GetInstance<EmployeeListPage>();
        }

        public HomePage ClickLogOff()
        {
            LinkLogOff.Click();
            DriverContext.Driver.WaitForPageLoaded();
            return GetInstance<HomePage>();
        }
    }
}