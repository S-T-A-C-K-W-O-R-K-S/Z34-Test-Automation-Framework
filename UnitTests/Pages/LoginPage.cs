using Framework.Base;
using Framework.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UnitTests.Pages
{
    internal class LoginPage : BasePage
    {
        [FindsBy(How = How.LinkText, Using = "Log in")]
        private IWebElement LinkLogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        private IWebElement LinkEmployeeList { get; set; }

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
            ButtonLogin.Submit();
        }

        public void ClickLoginLink()
        {
            LinkLogin.Click();
        }

        public EmployeeListPage ClickEmployeeList()
        {
            LinkEmployeeList.Click();
            DriverContext.Driver.WaitForPageLoaded();
            return GetInstance<EmployeeListPage>();
        }

        internal void AssertLoginFormExists()
        {
            TextUserName.AssertElementPresent();
            TextPassword.AssertElementPresent();
        }
    }
}