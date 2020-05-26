using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace FrameworkCore.Extensions
{
    public static partial class WebElementExtensions
    {
        public static string GetSelectedOptionText(this IWebElement element)
        {
            SelectElement select = new SelectElement(element);

            if (!select.IsMultiple)
                return select.SelectedOption.ToString();

            return "INVALID SELECTION";
        }

        public static void SelectFromDropdownListByText(this IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);

            if (!select.IsMultiple)
                select.SelectByText(value);
        }

        public static void SelectFromDropdownListByIndex(this IWebElement element, int value)
        {
            SelectElement select = new SelectElement(element);

            if (!select.IsMultiple && Enumerable.Range(0, GetOptionsCount(element) - 1).ToList().Contains(value))
                select.SelectByIndex(value);
        }
    }
}
