using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;

namespace FrameworkCore.Base
{
    public class ParallelTestExecution
    {
        public RemoteWebDriver Driver { get; set; }
        public BasePage CurrentPage { get; set; }
    }
}