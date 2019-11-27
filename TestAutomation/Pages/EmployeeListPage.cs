using FrameworkCore.Base;
using FrameworkCore.Extensions;
using FrameworkCore.Helpers;
using OpenQA.Selenium;

namespace TestAutomation.Pages
{
    internal class EmployeeListPage : BasePage
    {
        public EmployeeListPage(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution)
        {
        }

        private IWebElement TextSearch => ParallelTestExecution.Driver.FindElement(By.Name("searchTerm"), 2500);
        private IWebElement LinkCreateNew => ParallelTestExecution.Driver.FindElement(By.LinkText("Create New"), 2500);
        private IWebElement TableEmployeeList => ParallelTestExecution.Driver.FindElement(By.ClassName("table"), 2500);

        public CreateEmployeePage ClickCreateNew()
        {
            LinkCreateNew.Click();
            ParallelTestExecution.Driver.WaitForPageLoaded();
            return new CreateEmployeePage(ParallelTestExecution);
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