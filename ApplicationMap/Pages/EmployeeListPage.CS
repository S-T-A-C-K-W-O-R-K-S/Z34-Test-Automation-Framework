using ApplicationMap.CommonElements;
using FrameworkCore.Base;
using FrameworkCore.Extensions;
using OpenQA.Selenium;

namespace ApplicationMap.Pages
{
    public class EmployeeListPage : BasePage
    {
        public EmployeeListPage(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

        private IWebElement TextSearch => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Name("searchTerm"));
        private IWebElement LinkCreateNew => ParallelTestExecution.Driver.FindElementOrTimeOut(By.LinkText("Create New"));
        private IWebElement TableEmployeeList => ParallelTestExecution.Driver.FindElementOrTimeOut(By.ClassName("table"));

        public CreateEmployeePage ClickCreateNew()
        {
            LinkCreateNew.Click();
            ParallelTestExecution.Driver.WaitForPageLoaded();
            return new CreateEmployeePage(ParallelTestExecution);
        }

        public IWebElement GetEmployeeList()
        {
            return TableEmployeeList;
        }

        public void PopulateSearchBox(string name)
        {
            TextSearch.SendKeys(name);
        }

        public bool AssertEmployeePresence(string name)
        {
            return HTMLTable.AssertValuePresence(HTMLTable.ReadTableToArray(TableEmployeeList), name);
        }
    }
}