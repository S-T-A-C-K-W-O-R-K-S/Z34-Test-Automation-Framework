namespace FrameworkCore.Base
{
    public class DriverContext
    {
        public readonly ParallelTestExecution ParallelTestExecution;

        public DriverContext(ParallelTestExecution parallelTestExecution)
        {
            ParallelTestExecution = parallelTestExecution;
        }

        public Browser Browser { get; set; }

        public void GoToURL(string url)
        {
            ParallelTestExecution.Driver.Url = url;
        }
    }
}