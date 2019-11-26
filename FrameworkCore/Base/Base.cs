using System;
using TechTalk.SpecFlow;

namespace FrameworkCore.Base
{
    public class Base
    {
        public readonly ParallelTestExecution ParallelTestExecution;

        public Base(ParallelTestExecution parallelTestExecution)
        {
            ParallelTestExecution = parallelTestExecution;
        }

        protected TPage GetInstance<TPage>() where TPage : BasePage, new()
        {
            return (TPage) Activator.CreateInstance(typeof(TPage));
        }

        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage) this;
        }
    }
}