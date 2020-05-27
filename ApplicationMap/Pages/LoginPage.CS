using FrameworkCore.Base;
using FrameworkCore.Extensions;
using OpenQA.Selenium;

namespace ApplicationMap.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

        private IWebElement TextEmailAddress => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Id("exampleInputEmail"));
        private IWebElement TextPassword => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Id("exampleInputPassword"));
        private IWebElement InputRememberMe => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("input#customCheck[type='checkbox']"));
        private IWebElement ButtonLogin => ParallelTestExecution.Driver.FindElementOrTimeOut(By.LinkText("Login"));

        public bool LoginFormExists()
        {
            return TextEmailAddress.ElementIsDisplayed() && TextPassword.ElementIsDisplayed();
        }

        public void EnterCredentials(string email, string password)
        {
            TextEmailAddress.SendKeys(email);
            TextPassword.SendKeys(password);
        }

        public void ClickRememberMe()
        {
            InputRememberMe.Click();
        }

        public Dashboard ClickLoginButton()
        {
            ButtonLogin.Click();
            ParallelTestExecution.Driver.WaitForPageLoaded();
            return new Dashboard(ParallelTestExecution);
        }
    }
}
