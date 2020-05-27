using FrameworkCore.Base;
using FrameworkCore.Extensions;
using OpenQA.Selenium;
using System;

namespace ApplicationMap.CommonElements
{
    public class Sidebar : BaseElement
    {
        public Sidebar(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

        private IWebElement LinkPagesAddon => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("a.nav-link[data-target='#collapsePages']"));

        public bool PagesAddonIsCollapsed()
        {
            return LinkPagesAddon.HasClass("collapsed");
        }

        public Collapse ClickPagesAddon()
        {
            return PagesAddonIsCollapsed() ? new Collapse(ParallelTestExecution) : null;
        }

        public class Collapse : BaseElement
        {
            public Collapse(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

            private IWebElement LinkLoginPage => ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("a.collapse-item[href*='login']"));
        }


    }
}
