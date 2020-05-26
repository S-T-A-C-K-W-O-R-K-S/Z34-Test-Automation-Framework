using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using FrameworkCore.Helpers;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameworkCore.Extensions
{
    public static class WebElementExtensions
    {
        #region Common Element Extensions

        [SuppressMessage("Design", "CA1031:Do Not Catch General Exception Types", Justification = "Exception Type Is Unknown")]
        public static bool ElementIsDisplayed(this IWebElement element)
        {
            try { return element.Displayed; }

            catch (Exception exception)
            {
                LogHelpers.WriteToLog($"[ERROR] :: Element Not Found :: {element} :: {exception.Message}");
                return false;
            }
        }

        public static string GetElementText(this IWebElement element) { return element.Text; }

        #endregion Common Element Extensions


        #region Select Element Extensions

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

        #endregion Select Element Extensions


        #region Single-Select Element Extensions

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

            if (!select.IsMultiple && Enumerable.Range(0, GetOptionsCount(element)-1).ToList().Contains(value))
                select.SelectByIndex(value);
        }

        #endregion Single-Select Element Extensions


        #region Multi-Select Element Extensions

        public static IList<string> GetSelectedOptionsText(this IWebElement element)
        {
            SelectElement select = new SelectElement(element);

            return select.AllSelectedOptions.Select(option => option.ToString()).ToList();
        }

        #endregion Multi-Select Element Extensions


        #region HTML Table Extensions

        public static HtmlNode GetHTTPTableNode(this IWebElement element)
        {
            // TODO: Implement GetHTTPTableNode via HtmlAgilityPack

            return null;
        }

        public static IList<HtmlNode> GetHTTPTableNodes()
        {
            // TODO: Implement GetHTTPTableNodes via HtmlAgilityPack

            return null;
        }

        /* * * * *
         * https://dotnetfiddle.net/UXCBxf
         * https://stackoverflow.com/questions/13005098/parsing-html-table-in-c-sharp
         * https://html-agility-pack.net/documentation
         */

        #endregion HTML Table Extensions
    }
}
