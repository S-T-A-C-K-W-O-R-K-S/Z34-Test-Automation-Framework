using FrameworkCore.Base;
using FrameworkCore.Extensions;
using FrameworkCore.Models;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace ApplicationMap.Pages
{
    public class TablesPage : BasePage
    {
        public TablesPage(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

        private HTMLTable TableStaffData => WebElementExtensions.ParseHTMLTableByXPath(this.PageSource, "//table");
        private ReadOnlyCollection<IWebElement> ListPagination => ParallelTestExecution.Driver.FindElementsOrTimeOut(By.CssSelector("ul.pagination a.page-link"));
    }
}
