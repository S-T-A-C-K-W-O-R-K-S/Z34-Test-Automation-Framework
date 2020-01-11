using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FrameworkCore.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameworkCore.Extensions
{
    public static class WebElementExtensions
    {
        public static string GetSelectedDropdownOption(this IWebElement element)
        {
            SelectElement dropdown = new SelectElement(element);
            return dropdown.SelectedOption.ToString();
        }

        public static IList<string> GetSelectedDropdownOptions(this IWebElement element)
        {
            SelectElement dropdown = new SelectElement(element);

            return dropdown.AllSelectedOptions.Select(option => option.ToString()).ToList();
        }

        public static void SelectByTextFromDropdownList(this IWebElement element, string value)
        {
            SelectElement dropdown = new SelectElement(element);
            dropdown.SelectByText(value);
        }

        [SuppressMessage("Design", "CA1031:Do Not Catch General Exception Types", Justification = "Exception Type Is Unknown")]
        public static bool ElementIsDisplayed(this IWebElement element)
        {
            try
            {
                return element.Displayed;
            }

            catch (Exception exception)
            {
                LogHelpers.WriteToLog($"[ERROR] :: Element Not Found :: {element} :: {exception.Message}");
                return false;
            }
        }

        public static string GetElementText(this IWebElement element)
        {
            return element.Text;
        }
    }
}