namespace FrameworkCore.Base
{
    public abstract class BasePage : Base
    {
        protected BasePage(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution) { }

        public string PageTitle => ParallelTestExecution.Driver.Title;
        public string PageSource => ParallelTestExecution.Driver.PageSource;
    }
}
