using FrameworkCore.Base;
using FrameworkCore.Extensions;
using OpenQA.Selenium;

namespace ApplicationMap.CommonElements
{
    public class Navbar : BaseElement
    {
        private readonly IWebElement Self;

        public Navbar(ParallelTestExecution parallelTestExecution) : base(parallelTestExecution)
        {
            this.Self = ParallelTestExecution.Driver.FindElementOrTimeOut(By.CssSelector("nav.navbar"));
        }
    }
}
