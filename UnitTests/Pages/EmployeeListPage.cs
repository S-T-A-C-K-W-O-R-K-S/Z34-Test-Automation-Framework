using Framework.Base;
using Framework.Extensions;
using OpenQA.Selenium;

namespace UnitTests.Pages
{
    internal class EmployeeListPage : BasePage
    {
        private static IWebElement TextSearch => DriverContext.Driver.FindElement(By.Name("searchTerm"));
        private static IWebElement LinkCreateNew => DriverContext.Driver.FindElement(By.LinkText("Create New"));
        private static IWebElement TableEmployeeList => DriverContext.Driver.FindElement(By.ClassName("table"));

        public CreateEmployeePage ClickCreateNew()
        {
            LinkCreateNew.Click();
            DriverContext.Driver.WaitForPageLoaded();
            return new CreateEmployeePage();
        }

        internal IWebElement GetEmployeeList() => TableEmployeeList;
    }
}