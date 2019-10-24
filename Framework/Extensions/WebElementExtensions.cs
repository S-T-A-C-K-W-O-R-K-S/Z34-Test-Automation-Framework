using System;
using System.Collections.Generic;
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
            List<string> options = new List<string>();

            foreach (IWebElement option in dropdown.AllSelectedOptions) options.Add(option.ToString());

            return options;
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

        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }

            catch (Exception exception)
            {
                LogHelpers.WriteToLog("ERROR :: " + exception.Message);
                return false;
            }
        }

        public static void HoverElement(this IWebElement element)
        {
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(element).Perform();
        }
    }
}