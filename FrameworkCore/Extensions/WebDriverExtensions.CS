using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using FrameworkCore.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FrameworkCore.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForPageLoaded(this IWebDriver driver, int timeoutInMilliseconds = 5000)
        {
            driver.WaitForCondition(dri =>
            {
                string state = ((IJavaScriptExecutor)dri).ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            }, timeoutInMilliseconds);
        }

        [SuppressMessage("Design", "CA1031: Do Not Catch General Exception Types", Justification = "Exception Type Is Unknown")]
        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeout)
        {
            bool Execute(T arg)
            {
                try { return condition(arg); }

                catch (Exception exception)
                {
                    LogHelpers.WriteToLog($"[ERROR] :: {exception.Message}");
                    return false;
                }
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds < timeout)
                if (Execute(obj))
                    break;
        }

        public static IWebElement FindElementOrTimeOut(this IWebDriver driver, By by, int timeoutInMilliseconds = 2500)
        {
            try
            {
                if (timeoutInMilliseconds <= 0) return driver.FindElement(by);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutInMilliseconds));
                return wait.Until(webDriver => webDriver.FindElement(by));
            }

            catch (Exception exception)
            {
                LogHelpers.WriteToLog($"[ERROR] :: Element Not Found :: {by} :: {exception.Message}");
                throw new NoSuchElementException($"No Such Element: {by}");
            }
        }

        public static ReadOnlyCollection<IWebElement> FindElementsOrTimeOut(this IWebDriver driver, By by, int timeoutInMilliseconds = 5000)
        {
            try
            {
                if (timeoutInMilliseconds <= 0) return driver.FindElements(by);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutInMilliseconds));
                return wait.Until(drv => drv.FindElements(by).Count > 0 ? drv.FindElements(by) : null);
            }

            catch (Exception exception)
            {
                LogHelpers.WriteToLog($"[ERROR] :: No Elements Found :: {by} :: {exception.Message}");
                throw new NoSuchElementException($"No Such Elements: {by}");
            }
        }
    }
}
