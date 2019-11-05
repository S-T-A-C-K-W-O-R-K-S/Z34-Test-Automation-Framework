using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Framework.Base;
using Framework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Framework.Extensions
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

        public static void AssertElementPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(string.Format("Element Not Present: " + element));
        }

        [SuppressMessage("Design", "CA1031:Do Not Catch General Exception Types", Justification = "Exception Type Is Unknown")]
        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }

            catch (Exception exception)
            {
                LogHelpers.WriteToLog("[ERROR] :: " + exception.Message);
                return false;
            }
        }

        public static void HoverElement(this IWebElement element)
        {
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(element).Perform();
        }

        public static string GetLinkText(this IWebElement element)
        {
            return element.Text;
        }
    }
}