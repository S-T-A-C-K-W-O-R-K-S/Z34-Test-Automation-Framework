using Framework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UnitTests.Pages
{
    class LoginPage : BasePage
    {
        [FindsBy(How = How.LinkText, Using = "Log in")]
        IWebElement LinkLogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        IWebElement LinkEmployeeList { get; set; }

        [FindsBy(How = How.Id, Using = "UserName")]
        IWebElement TextUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        IWebElement TextPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        IWebElement ButtonLogin { get; set; }

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

        public EmployeePage ClickEmployeeList()
        {
            LinkEmployeeList.Click();
            return GetInstance<EmployeePage>();
        }
    }
}
