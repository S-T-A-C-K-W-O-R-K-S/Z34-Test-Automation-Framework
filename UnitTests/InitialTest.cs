﻿using Framework.Base;
using Framework.Config;
using Framework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using UnitTests.Pages;

namespace UnitTests
{
    [TestClass]
    public class InitialTest : Base
    {
        readonly string url = ConfigReader.InitializeTest();

        public static void OpenBrowser(BrowserType browserType = BrowserType.Firefox)
        {
            switch (browserType)
            {
                case BrowserType.Firefox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }

        [TestMethod]
        public void ReachNewEmployeePage()
        {
            string dataSet = Environment.CurrentDirectory.ToString() + "\\Data\\Credentials.XLSX";
            ExcelDataHelpers.PopulateInMemoryCollection(dataSet);

            LogHelpers.CreateLogFile();
            LogHelpers.WriteToLog("Opened The Browser !");
            LogHelpers.WriteToLog("Did Something Else");

            OpenBrowser(BrowserType.Firefox);
            DriverContext.Browser.GoToUrl(url);

            CurrentPage = GetInstance<LoginPage>();

            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().Login(ExcelDataHelpers.ReadData(1, "UserName"), ExcelDataHelpers.ReadData(1, "Password"));

            CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();
            CurrentPage.As<EmployeePage>().ClickCreateNew();
        }

        [TestMethod]
        public void TableOperation()
        {
            string dataSet = Environment.CurrentDirectory.ToString() + "\\Data\\Credentials.XLSX";
            ExcelDataHelpers.PopulateInMemoryCollection(dataSet);

            LogHelpers.CreateLogFile();
            LogHelpers.WriteToLog("Opened The Browser !");
            LogHelpers.WriteToLog("Did Something Else");

            OpenBrowser(BrowserType.Firefox);
            DriverContext.Browser.GoToUrl(url);

            CurrentPage = GetInstance<LoginPage>();

            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().Login(ExcelDataHelpers.ReadData(1, "UserName"), ExcelDataHelpers.ReadData(1, "Password"));

            CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();

            var table = CurrentPage.As<EmployeePage>().GetEmployeeList();

            HtmlTableHelpers.ReadTable(table);
            HtmlTableHelpers.PerformActionOnCell("6", "Name", "Ramesh", "Edit");
        }
    }
}
