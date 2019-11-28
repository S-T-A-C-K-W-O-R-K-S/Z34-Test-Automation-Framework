using FrameworkCore.Base;
using FrameworkCore.Extensions;
using OpenQA.Selenium;

namespace TestRunner.Pages
{
    internal class LoginPage : BasePage
    {
        public LoginPage(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution)
        {
        }

        private IWebElement TextUserName => ParallelTestExecution.Driver.FindElement(By.Id("UserName"), 2500);
        private IWebElement TextPassword => ParallelTestExecution.Driver.FindElement(By.Id("Password"), 2500);
        private IWebElement ButtonLogin => ParallelTestExecution.Driver.FindElement(By.CssSelector("input.btn"), 2500);

        internal void EnterCredentials(string userName, string password)
        {
            TextUserName.SendKeys(userName);
            TextPassword.SendKeys(password);
        }

        public HomePage ClickLoginButton()
        {
            ButtonLogin.Click();
            ParallelTestExecution.Driver.WaitForPageLoaded();
            return new HomePage(ParallelTestExecution);
        }

        internal void AssertLoginFormExists()
        {
            TextUserName.AssertElementPresent();
            TextPassword.AssertElementPresent();
        }
    }
}