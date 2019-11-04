using Framework.Base;
using Framework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTests.Pages
{
    internal class HomePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "#loginLink")]
        private IWebElement LinkLogIn { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        private IWebElement LinkEmployeeList { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Manage']")]
        private IWebElement LinkLoggedInUser { get; set; }

        [FindsBy(How = How.LinkText, Using = "Log Off")]
        private IWebElement LinkLogOff { get; set; }

        internal void AssertLoginLinkPresence()
        {
            LinkLogIn.AssertElementPresent();
        }

        internal LoginPage ClickLogIn()
        {
            LinkLogIn.Click();
            return GetInstance<LoginPage>();
        }

        internal string GetLoggedInUser()
        {
            return LinkLoggedInUser.GetLinkText();
        }

        internal EmployeeListPage ClickEmployeeList()
        {
            LinkEmployeeList.Click();
            return GetInstance<EmployeeListPage>();
        }

        internal HomePage ClickLogOff()
        {
            LinkLogOff.Click();
            return GetInstance<HomePage>();
        }
    }
}