using FrameworkCore.Base;
using FrameworkCore.Extensions;
using FrameworkCore.Helpers;
using OpenQA.Selenium;

namespace TestAutomation.Pages
{
    internal class EmployeeListPage : BasePage
    {
        private static IWebElement TextSearch => DriverContext.Driver.FindElement(By.Name("searchTerm"), 2500);
        private static IWebElement LinkCreateNew => DriverContext.Driver.FindElement(By.LinkText("Create New"), 2500);
        private static IWebElement TableEmployeeList => DriverContext.Driver.FindElement(By.ClassName("table"), 2500);

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

        internal void PopulateSearchBox(string name)
        {
            TextSearch.SendKeys(name);
        }

        internal bool AssertEmployeePresence(string name)
        {
            return HTMLTableHelpers.AssertValuePresence(HTMLTableHelpers.ReadTableToArray(TableEmployeeList), name);
        }
    }
}