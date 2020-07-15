using FrameworkCore.Base;
using FrameworkCore.Extensions;
using OpenQA.Selenium;

namespace ApplicationMap.CommonElements
{
    public class Sidebar : BaseElement
    {
        public readonly IWebElement Self;

        public Sidebar(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution)
        {
            this.Self = ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("ul#accordionSidebar"));
        }

        private IWebElement LinkPagesAddon => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("a.nav-link[data-target='#collapsePages']"));
        public IWebElement LinkCharts => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("a.nav-link[href*='charts']"));
        public IWebElement LinkTables => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("a.nav-link[href*='tables']"));

        public bool PagesAddonIsCollapsed()
        {
            return LinkPagesAddon.HasClass("collapsed");
        }

        public Collapse ClickPagesAddon()
        {
            LinkPagesAddon.Click();
            return PagesAddonIsCollapsed() ? new Collapse(ParallelTestExecution) : null;
        }

        public class Collapse : BaseElement
        {
            public Collapse(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

            private IWebElement LinkLoginPage => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("a.collapse-item[href*='login']"));
        }
    }
}
