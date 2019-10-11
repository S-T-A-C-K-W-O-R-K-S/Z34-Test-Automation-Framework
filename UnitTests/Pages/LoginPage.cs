using Framework.Base;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UnitTests.Pages
{
    class LoginPage : BasePage
    {
        [FindsBy(How = How.LinkText, Using = "Log in")]
        public IWebElement LnkLogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        public IWebElement LnkEmployeeList { get; set; }

        [FindsBy(How = How.Id, Using = "UserName")]
        public IWebElement TxtUserName { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input.btn")]
        public IWebElement BtnLogin { get; set; }

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
            return new EmployeePage();
        }
    }
}
