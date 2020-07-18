using FrameworkCore.Base;
using FrameworkCore.Extensions;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace ApplicationMap.Pages
{
    class TablesPage : BasePage
    {
        public TablesPage(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

        private IWebElement TableStaffData => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Id("dataTable"));
        private ReadOnlyCollection<IWebElement> ListPagination => ParallelTestExecution.Driver.FindElementsOrTimeOut(By.CssSelector("ul.pagination a.page-link"));
    }
}
