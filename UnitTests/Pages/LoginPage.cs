using Framework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UnitTests.Pages
{
    class LoginPage : BasePage
    {
        [FindsBy(How = How.LinkText, Using = "Log in")]
        IWebElement LnkLogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        IWebElement LnkEmployeeList { get; set; }

        [FindsBy(How = How.Id, Using = "UserName")]
        IWebElement TxtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        IWebElement BtnLogin { get; set; }

        public void Login(string userName, string password)
        {
            TxtUserName.SendKeys(userName);
            TxtPassword.SendKeys(password);
            BtnLogin.Submit();
        }

        public void ClickLoginLink()
        {
            LnkLogin.Click();
        }

        public EmployeePage ClickEmployeeList()
        {
            LnkEmployeeList.Click();
            return GetInstance<EmployeePage>();
        }
    }
}
