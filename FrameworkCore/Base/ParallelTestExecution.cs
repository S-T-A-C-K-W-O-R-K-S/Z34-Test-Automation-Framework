using OpenQA.Selenium;

namespace FrameworkCore.Base
{
    public class ParallelTestExecution
    {
        public IWebDriver Driver { get; set; }
        public BasePage CurrentPage { get; set; }
    }
}