using FrameworkCore.Base;
using FrameworkCore.Extensions;
using OpenQA.Selenium;

namespace ApplicationMap.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

        private IWebElement LinkLogIn => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("a#loginLink"));
        private IWebElement LinkEmployeeList => ParallelTestExecution.Driver.FindElementOrTimeOut(By.LinkText("Employee List"));
        private IWebElement LinkLoggedInUser => ParallelTestExecution.Driver.FindElementOrTimeOut(By.XPath("//a[@title='Manage']"));
        private IWebElement LinkLogOff => ParallelTestExecution.Driver.FindElementOrTimeOut(By.LinkText("Log off"));

        public void AssertLoginLinkPresence() => LinkLogIn.ElementIsDisplayed();

        public LoginPage ClickLogIn()
        {
            LinkLogIn.Click();
            ParallelTestExecution.Driver.WaitForPageLoaded();
            return new LoginPage(ParallelTestExecution);
        }

        public string GetLoggedInUser() => LinkLoggedInUser.GetElementText();

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