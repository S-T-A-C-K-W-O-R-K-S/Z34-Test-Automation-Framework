using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace FrameworkCore.Base
{
    public class ParallelTestExecution
    {
        public IWebDriver Driver { get; set; }
        public BasePage CurrentPage { get; set; }
    }
}