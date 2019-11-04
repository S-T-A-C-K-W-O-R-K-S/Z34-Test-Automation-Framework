//using System;
//using Framework.Helpers;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using UnitTests.Pages;

//namespace UnitTests.Tests
//{
//    [TestClass]
//    public class InitialTest : HookInitialize
//    {
//        [TestMethod]
//        public void ReachNewEmployeePage()
//        {
//            string dataSet = Environment.CurrentDirectory + "\\Data\\Credentials.XLSX";
//            ExcelDataHelpers.PopulateInMemoryCollection(dataSet);

//            LogHelpers.WriteToLog("Test One !");

//            CurrentPage = GetInstance<HomePage>();
//            CurrentPage = CurrentPage.As<HomePage>().ClickLogin();
//            CurrentPage.As<LoginPage>().AssertLoginFormExists();

//            CurrentPage.As<LoginPage>().EnterCredentials(ExcelDataHelpers.ReadData(1, "UserName"), ExcelDataHelpers.ReadData(1, "Password"));
//            CurrentPage.As<LoginPage>().ClickLoginButton();

//            CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeList();
//            CurrentPage.As<EmployeeListPage>().ClickCreateNew();
//        }

//        [TestMethod]
//        public void TableOperation()
//        {
//            string dataSet = Environment.CurrentDirectory + "\\Data\\Credentials.XLSX";
//            ExcelDataHelpers.PopulateInMemoryCollection(dataSet);

//            LogHelpers.WriteToLog("Test Two !");

//            CurrentPage = GetInstance<HomePage>();
//            CurrentPage = CurrentPage.As<HomePage>().ClickLogin();

//            CurrentPage.As<LoginPage>().EnterCredentials(ExcelDataHelpers.ReadData(1, "UserName"), ExcelDataHelpers.ReadData(1, "Password"));
//            CurrentPage.As<LoginPage>().ClickLoginButton();

//            CurrentPage = CurrentPage.As<HomePage>().ClickEmployeeList();

//            IWebElement table = CurrentPage.As<EmployeeListPage>().GetEmployeeList();

//            HtmlTableHelpers.ReadTable(table);
//            HtmlTableHelpers.PerformActionOnCell("6", "Name", "Ramesh", "Edit");
//        }
//    }
//}