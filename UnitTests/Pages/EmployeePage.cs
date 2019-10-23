using Framework.Base;
using Framework.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UnitTests.Pages
{
    class EmployeePage : BasePage
    {
        [FindsBy(How = How.Name, Using = "searchTerm")]
        IWebElement TextSearch { get; set; }

        [FindsBy(How = How.LinkText, Using = "Create New")]
        IWebElement LinkCreateNew { get; set; }

        [FindsBy(How = How.ClassName, Using = "table")]
        IWebElement TableEmployeeList { get; set; }

        public CreateEmployeePage ClickCreateNew()
        {
            LinkCreateNew.Click();
            DriverContext.Driver.WaitForPageLoaded();
            return new CreateEmployeePage();
        }

        public IWebElement GetEmployeeList()
        {
            return TableEmployeeList;
        }
    }
}
