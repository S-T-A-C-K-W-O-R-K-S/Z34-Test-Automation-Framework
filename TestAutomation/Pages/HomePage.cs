using FrameworkCore.Base;
using FrameworkCore.Extensions;
using OpenQA.Selenium;

namespace TestAutomation.Pages
{
    internal class HomePage : BasePage
    {
        public HomePage(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution)
        {
        }

        private IWebElement LinkLogIn => ParallelTestExecution.Driver.FindElement(By.CssSelector("a#loginLink"), 2500);
        private IWebElement LinkEmployeeList => ParallelTestExecution.Driver.FindElement(By.LinkText("Employee List"), 2500);
        private IWebElement LinkLoggedInUser => ParallelTestExecution.Driver.FindElement(By.XPath("//a[@title='Manage']"), 2500);
        private IWebElement LinkLogOff => ParallelTestExecution.Driver.FindElement(By.LinkText("Log off"), 2500);

        internal void AssertLoginLinkPresence() => LinkLogIn.AssertElementPresent();

        public LoginPage ClickLogIn()
        {
            LinkLogIn.Click();
            ParallelTestExecution.Driver.WaitForPageLoaded();
            return new LoginPage(ParallelTestExecution);
        }

        internal string GetLoggedInUser() => LinkLoggedInUser.GetLinkText();

        public EmployeeListPage ClickEmployeeList()
        {
            LinkEmployeeList.Click();
            ParallelTestExecution.Driver.WaitForPageLoaded();
            return new EmployeeListPage(ParallelTestExecution);
        }

        public HomePage ClickLogOff()
        {
            LinkLogOff.Click();
            ParallelTestExecution.Driver.WaitForPageLoaded();
            return new HomePage(ParallelTestExecution);
        }
    }
}