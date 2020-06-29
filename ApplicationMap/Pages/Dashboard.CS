using ApplicationMap.CommonElements;
using FrameworkCore.Base;

namespace ApplicationMap.Pages
{
    public class Dashboard : BasePage
    {
        public Dashboard(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

        public Navbar Navbar => new Navbar(ParallelTestExecution);
        public Sidebar Sidebar => new Sidebar(ParallelTestExecution);
    }
}
