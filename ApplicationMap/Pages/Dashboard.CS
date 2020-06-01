using ApplicationMap.CommonElements;
using FrameworkCore.Base;

namespace ApplicationMap.Pages
{
    public class Dashboard : BasePage
    {
        public Dashboard(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

        private Navbar Navbar => new Navbar(ParallelTestExecution);
        private Sidebar Sidebar => new Sidebar(ParallelTestExecution);
    }
}
