namespace FrameworkCore.Base
{
    public class Base
    {
        public readonly ParallelTestExecution ParallelTestExecution;

        public Base(ParallelTestExecution parallelTestExecution) { ParallelTestExecution = parallelTestExecution; }

        public TPage AsPage<TPage>() where TPage : BasePage { return (TPage) this; }

        public TElement AsElement<TElement>() where TElement : BaseElement { return (TElement) this; }
    }
}
