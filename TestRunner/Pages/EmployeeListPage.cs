using FrameworkCore.Base;
using FrameworkCore.Extensions;
using FrameworkCore.Helpers;
using OpenQA.Selenium;

namespace TestRunner.Pages
{
    internal class EmployeeListPage : BasePage
    {
        public EmployeeListPage(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution)
        {
        }

        private IWebElement TextSearch => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Name("searchTerm"));
        private IWebElement LinkCreateNew => ParallelTestExecution.Driver.FindElementOrTimeOut(By.LinkText("Create New"));
        private IWebElement TableEmployeeList => ParallelTestExecution.Driver.FindElementOrTimeOut(By.ClassName("table"));

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