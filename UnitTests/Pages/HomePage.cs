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
        private IWebElement LinkLogOff { get; set; }

        internal void CheckIfLoginExist()
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

        public EmployeePage ClickEmployeeList()
        {
            LinkEmployeeList.Click();
            return GetInstance<EmployeePage>();
        }
    }
}