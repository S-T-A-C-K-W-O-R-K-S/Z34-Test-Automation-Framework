using Framework.Base;
using Framework.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

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

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeout)
        {
            Func<T, bool> execute = (arg) =>
            {
                try
                {
                    return condition(arg);
                }

                catch (Exception exception)
                {
                    LogHelpers.WriteToLog("ERROR :: " + exception.Message);
                    return false;
                }
            };

            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds < timeout)
            {
                if(execute(obj))
                {
                    break;
                }
            }
        }

        internal static object ExecuteJS(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }
    }
}
