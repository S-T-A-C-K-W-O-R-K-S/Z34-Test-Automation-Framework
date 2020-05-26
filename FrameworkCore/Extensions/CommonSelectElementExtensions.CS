using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace FrameworkCore.Extensions
{
    public static partial class WebElementExtensions
    {
        public static IList<string> GetOptionsText(this IWebElement element)
        {
            SelectElement select = new SelectElement(element);
            return (IList<string>)select.Options.ToString().ToList();
        }

        public static int GetOptionsCount(this IWebElement element)
        {
            SelectElement select = new SelectElement(element);
            return select.Options.ToList().Count();
        }
    }
}
