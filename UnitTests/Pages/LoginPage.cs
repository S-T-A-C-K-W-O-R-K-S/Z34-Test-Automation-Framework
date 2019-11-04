using Framework.Base;
using Framework.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UnitTests.Pages
{
    internal class LoginPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "UserName")]
        private IWebElement TextUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement TextPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        private IWebElement ButtonLogin { get; set; }

        public void Login(string userName, string password)
        {
            TextUserName.SendKeys(userName);
            TextPassword.SendKeys(password);
        }

        public HomePage ClickLoginButton()
        {
            ButtonLogin.Click();
            return GetInstance<HomePage>();
        }

        internal void AssertLoginFormExists()
        {
            TextUserName.AssertElementPresent();
            TextPassword.AssertElementPresent();
        }
    }
}