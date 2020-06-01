using ApplicationMap.CommonElements;
using FrameworkCore.Base;

namespace ApplicationMap.Pages
{
    public class Dashboard : BasePage
    {
        private readonly Navbar Navbar;
        private readonly Sidebar Sidebar;

        public Dashboard(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution)
        {
            this.Navbar = new Navbar(ParallelTestExecution);
            this.Sidebar = new Sidebar(ParallelTestExecution);
        }
    }
}
