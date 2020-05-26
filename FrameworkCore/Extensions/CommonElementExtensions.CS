using System;
using System.Diagnostics.CodeAnalysis;
using FrameworkCore.Helpers;
using OpenQA.Selenium;

namespace FrameworkCore.Extensions
{
    public static partial class WebElementExtensions
    {
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
    }
}
