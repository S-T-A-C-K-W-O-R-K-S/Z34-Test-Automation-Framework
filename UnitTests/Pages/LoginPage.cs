using Framework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UnitTests.Pages
{
    class LoginPage : BasePage
    {
        [FindsBy(How = How.LinkText, Using = "Log in")]
        public IWebElement LnkLogin { get; set; }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement TxtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        public IWebElement BtnLogin { get; set; }
    }
}
