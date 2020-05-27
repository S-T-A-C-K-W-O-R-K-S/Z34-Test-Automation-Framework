using FrameworkCore.Base;
using FrameworkCore.Extensions;
using OpenQA.Selenium;

namespace ApplicationMap.Pages
{
    public class Dashboard : BasePage
    {
        public Dashboard(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

        // TODO Sidebar = new Sidebar(ParallelTestExecution); Navbar = new Navbar(ParallelTestExecution);
    }
}
