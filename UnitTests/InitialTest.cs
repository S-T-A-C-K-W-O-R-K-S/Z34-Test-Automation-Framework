using System;
using Framework.Base;
using Framework.Config;
using Framework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using UnitTests.Pages;

namespace UnitTests
{
    [TestClass]
    public class InitialTest : Base
    {
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
            ConfigReader.SetFrameworkSettings();

            string dataSet = Environment.CurrentDirectory + "\\Data\\Credentials.XLSX";
            ExcelDataHelpers.PopulateInMemoryCollection(dataSet);

            LogHelpers.CreateLogFile();
            LogHelpers.WriteToLog("Test One !");

            OpenBrowser(BrowserType.Chrome);
            DriverContext.Browser.GoToUrl(Settings.AUT);

            CurrentPage = GetInstance<LoginPage>();

            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().AssertLoginFormExists();

            CurrentPage.As<LoginPage>().Login(ExcelDataHelpers.ReadData(1, "UserName"), ExcelDataHelpers.ReadData(1, "Password"));
            CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();
            CurrentPage.As<EmployeePage>().ClickCreateNew();
        }

        [TestMethod]
        public void TableOperation()
        {
            ConfigReader.SetFrameworkSettings();

            string dataSet = Environment.CurrentDirectory + "\\Data\\Credentials.XLSX";
            ExcelDataHelpers.PopulateInMemoryCollection(dataSet);

            LogHelpers.CreateLogFile();
            LogHelpers.WriteToLog("Test Two !");

            OpenBrowser(BrowserType.Chrome);
            DriverContext.Browser.GoToUrl(Settings.AUT);

            CurrentPage = GetInstance<LoginPage>();

            CurrentPage.As<LoginPage>().ClickLoginLink();
            CurrentPage.As<LoginPage>().Login(ExcelDataHelpers.ReadData(1, "UserName"), ExcelDataHelpers.ReadData(1, "Password"));

            CurrentPage = CurrentPage.As<LoginPage>().ClickEmployeeList();

            IWebElement table = CurrentPage.As<EmployeePage>().GetEmployeeList();

            HtmlTableHelpers.ReadTable(table);
            HtmlTableHelpers.PerformActionOnCell("6", "Name", "Ramesh", "Edit");
        }
    }
}