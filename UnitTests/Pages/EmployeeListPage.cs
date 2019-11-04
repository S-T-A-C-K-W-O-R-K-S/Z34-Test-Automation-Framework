using Framework.Base;
using Framework.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UnitTests.Pages
{
    internal class EmployeeListPage : BasePage
    {
        [FindsBy(How = How.Name, Using = "searchTerm")]
        private IWebElement TextSearch { get; set; }

        [FindsBy(How = How.LinkText, Using = "Create New")]
        private IWebElement LinkCreateNew { get; set; }

        [FindsBy(How = How.ClassName, Using = "table")]
        private IWebElement TableEmployeeList { get; set; }

        public CreateEmployeePage ClickCreateNew()
        {
            LinkCreateNew.Click();
            DriverContext.Driver.WaitForPageLoaded();
            return new CreateEmployeePage();
        }

        internal IWebElement GetEmployeeList()
        {
            return TableEmployeeList;
        }
    }
}