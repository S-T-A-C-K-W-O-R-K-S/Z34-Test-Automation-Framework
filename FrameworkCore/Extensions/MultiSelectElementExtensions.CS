using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace FrameworkCore.Extensions
{
    public static partial class WebElementExtensions
    {
        public static IList<string> GetSelectedOptionsText(this IWebElement element)
        {
            SelectElement select = new SelectElement(element);

            return select.AllSelectedOptions.Select(option => option.ToString()).ToList();
        }
    }
}
