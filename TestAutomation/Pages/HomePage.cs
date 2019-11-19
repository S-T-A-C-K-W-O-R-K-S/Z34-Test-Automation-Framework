using FrameworkCore.Base;
using FrameworkCore.Extensions;
using OpenQA.Selenium;

namespace TestAutomation.Pages
{
    internal class HomePage : BasePage
    {
        private static IWebElement LinkLogIn => DriverContext.Driver.FindElement(By.CssSelector("a#loginLink"), 2500);
        private static IWebElement LinkEmployeeList => DriverContext.Driver.FindElement(By.LinkText("Employee List"), 2500);
        private static IWebElement LinkLoggedInUser => DriverContext.Driver.FindElement(By.XPath("//a[@title='Manage']"), 2500);
        private static IWebElement LinkLogOff => DriverContext.Driver.FindElement(By.LinkText("Log off"), 2500);

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