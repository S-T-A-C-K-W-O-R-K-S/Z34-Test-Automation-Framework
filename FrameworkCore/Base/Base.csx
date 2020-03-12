namespace FrameworkCore.Base
{
    public class Base
    {
        public readonly ParallelTestExecution ParallelTestExecution;

        public Base(ParallelTestExecution parallelTestExecution)
        {
            ParallelTestExecution = parallelTestExecution;
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage) this;
        }
    }
}