﻿using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Framework.Base;
using Framework.Helpers;
using OpenQA.Selenium;

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

        [SuppressMessage("Design", "CA1031: Do Not Catch General Exception Types", Justification = "It Is Not Knows What Exception Types This Method May Throw")]
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
                    LogHelpers.WriteToLog("ERROR :: " + exception.Message);
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
    }
}