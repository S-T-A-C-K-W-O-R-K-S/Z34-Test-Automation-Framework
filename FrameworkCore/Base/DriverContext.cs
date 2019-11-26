using OpenQA.Selenium;

namespace FrameworkCore.Base
{
    public class DriverContext
    {
        public readonly ParallelTestExecution ParallelTestExecution;

        public DriverContext(ParallelTestExecution parallelTestExecution)
        {
            ParallelTestExecution = parallelTestExecution;
        }

        public void GoToURL(string url)
        {
            ParallelTestExecution.Driver.Url = url;
        }

        public Browser Browser { get; set; }
    }
}