using Framework.Base;
using Framework.Extensions;
using OpenQA.Selenium;

namespace UnitTests.Pages
{
    internal class LoginPage : BasePage
    {
        private static IWebElement TextUserName => DriverContext.Driver.FindElement(By.Id("UserName"), 2500);
        private static IWebElement TextPassword => DriverContext.Driver.FindElement(By.Id("Password"), 2500);
        private static IWebElement ButtonLogin => DriverContext.Driver.FindElement(By.CssSelector("input.btn"), 2500);

        internal void EnterCredentials(string userName, string password)
        {
            TextUserName.SendKeys(userName);
            TextPassword.SendKeys(password);
        }

        public HomePage ClickLoginButton()
        {
            ButtonLogin.Click();
            DriverContext.Driver.WaitForPageLoaded();
            return GetInstance<HomePage>();
        }

        internal void AssertLoginFormExists()
        {
            TextUserName.AssertElementPresent();
            TextPassword.AssertElementPresent();
        }
    }
}