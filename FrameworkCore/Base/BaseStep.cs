using FrameworkCore.Config;
using FrameworkCore.Extensions;
using FrameworkCore.Helpers;

namespace FrameworkCore.Base
{
    public class BaseStep : Base
    {
        protected BaseStep (ParallelTestExecution parallelTestExecution) : base (parallelTestExecution)
        {
        }
    }
}