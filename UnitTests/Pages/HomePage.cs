using Framework.Base;
using Framework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTests.Pages
{
    internal class HomePage : BasePage
    {
        [FindsBy(How = How.LinkText, Using = "Login")]
        private IWebElement LinkLogIn { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        private IWebElement LinkEmployeeList { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Manage']")]
        private IWebElement LinkLoggedInUser { get; set; }

        [FindsBy(How = How.LinkText, Using = "Log Off")]
        private IWebElement LinkLogOff { get; set; }

        public void AssertLoginLinkPresence()
        {
            LinkLogIn.AssertElementPresent();
        }

        public LoginPage ClickLogIn()
        {
            LinkLogIn.Click();
            return GetInstance<LoginPage>();
        }

        public string GetLoggedInUser()
        {
            return LinkLoggedInUser.GetLinkText();
        }

        public EmployeeListPage ClickEmployeeList()
        {
            LinkEmployeeList.Click();
            return GetInstance<EmployeeListPage>();
        }

        public HomePage ClickLogOff()
        {
            LinkLogOff.Click();
            return GetInstance<HomePage>();
        }
    }
}