using System.Diagnostics.CodeAnalysis;
using Framework.Base;
using Framework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTests.Pages
{
    internal class HomePage : BasePage
    {
        [FindsBy(How = How.LinkText, Using = "Log In")]
        private IWebElement LinkLogIn { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        private IWebElement LinkEmployeeList { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@title='Manage']")]
        private IWebElement LinkLoggedInUser { get; set; }

        [FindsBy(How = How.LinkText, Using = "Log Off")]
        [SuppressMessage("Code Quality", "IDE0051: Remove Unused Private Members", Justification = "Will Use Eventually")]
        private IWebElement LinkLogOff { get; set; }

        internal void AssertLoginLinkPresence()
        {
            LinkLogIn.AssertElementPresent();
        }

        internal LoginPage ClickLogin()
        {
            LinkLogIn.Click();
            return GetInstance<LoginPage>();
        }

        internal string GetLoggedInUser()
        {
            return LinkLoggedInUser.GetLinkText();
        }

        public EmployeeListPage ClickEmployeeList()
        {
            LinkEmployeeList.Click();
            return GetInstance<EmployeeListPage>();
        }
    }
}