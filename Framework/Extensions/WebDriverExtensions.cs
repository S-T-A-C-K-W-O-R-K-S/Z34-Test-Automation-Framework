using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Framework.Base;
using Framework.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForPageLoaded(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = dri.ExecuteJS("return document.readyState").ToString();
                return state == "complete";
            }, 5000);
        }

        [SuppressMessage("Design", "CA1031: Do Not Catch General Exception Types", Justification = "Exception Type Is Unknown")]
        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeout)
        {
            bool Execute(T arg)
            {
                try
                {
                    return condition(arg);
                }

                catch (Exception exception)
                {
                    LogHelpers.WriteToLog("[ERROR] :: " + exception.Message);
                    return false;
                }
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds < timeout)
                if (Execute(obj))
                    break;
        }

        [SuppressMessage("Style", "IDE0060: Remove Unused Parameter", Justification = "Extension Method Needs IWebDriver Parameter")]
        internal static object ExecuteJS(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor) DriverContext.Driver).ExecuteScript(script);
        }

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInMilliseconds)
        {
            if (timeoutInMilliseconds <= 0) return driver.FindElement(by);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutInMilliseconds));
            return wait.Until(drv => drv.FindElement(by));
        }

        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInMilliseconds)
        {
            if (timeoutInMilliseconds <= 0) return driver.FindElements(by);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutInMilliseconds));
            return wait.Until(drv => drv.FindElements(by).Count > 0 ? drv.FindElements(by) : null);
        }
    }
}