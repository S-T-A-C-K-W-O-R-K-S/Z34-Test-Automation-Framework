using System;
using Framework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using UnitTests.Pages;

namespace UnitTests.Tests
{
    [TestClass]
    public class InitialTest : HookInitialize
    {
        [TestMethod]
        public void ReachNewEmployeePage()
        {
            string dataSet = Environment.CurrentDirectory + "\\Data\\Credentials.XLSX";
            ExcelDataHelpers.PopulateInMemoryCollection(dataSet);

            LogHelpers.WriteToLog("Test One !");

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
            string dataSet = Environment.CurrentDirectory + "\\Data\\Credentials.XLSX";
            ExcelDataHelpers.PopulateInMemoryCollection(dataSet);

            LogHelpers.WriteToLog("Test Two !");

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