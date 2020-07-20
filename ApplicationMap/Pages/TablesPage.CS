using FrameworkCore.Base;
using FrameworkCore.Extensions;
using FrameworkCore.Helpers;
using FrameworkCore.Models;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace ApplicationMap.Pages
{
    public class TablesPage : BasePage
    {
        public TablesPage(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

        private HTMLTable TableStaffDataParsed { get; set; }

        public IWebElement TableStaffData => ParallelTestExecution.Driver.FindElementOrTimeOut(By.Id("dataTable"));
        public ReadOnlyCollection<IWebElement> ListPagination => ParallelTestExecution.Driver.FindElementsOrTimeOut(By.CssSelector("ul.pagination a.page-link"));

        public void NavigateToTableTab(string tabText)
        {
            foreach (IWebElement tab in ListPagination)
            {
                if (tab.Text == tabText)
                {
                    tab.Click();
                    TableStaffDataParsed = WebElementExtensions.ParseHTMLTableByXPath(this.PageSource, "//table");
                    return;
                }
            }

            LogHelpers.WriteToLog($"[ERROR] :: Table Tab Not Found: {tabText}");
            throw new NoSuchElementException($"Table Tab Not Found: {tabText}");
        }

        public HTMLTable GetParsedTable()
        {
            return TableStaffDataParsed;
        }
    }
}
