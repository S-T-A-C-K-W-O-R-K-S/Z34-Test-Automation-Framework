using ApplicationMap.Pages;
using FrameworkCore.Base;
using FrameworkCore.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestRunner.ObjectModels;

namespace TestRunner.Steps
{
    [Binding]
    public class LoginSteps : BaseStep
    {
        private readonly FeatureContext _featureContext;
        private readonly ParallelTestExecution _parallelTestExecution;

        public LoginSteps(ParallelTestExecution parallelTestExecution, FeatureContext featureContext) : base(parallelTestExecution)
        {
            _parallelTestExecution = parallelTestExecution;
            _featureContext = featureContext;
        }

        [Given]
        public void Given_I_CONFIRM_THAT_THE_LOGIN_FORM_IS_DISPLAYED()
        {
            LogHelpers.WriteToLog(_parallelTestExecution.CurrentPage.AsPage<LoginPage>().LoginFormExists()
                ? $"[EVENT] :: [{_featureContext.FeatureInfo.Title.ToUpper()}] :: Login Form Exists On Login Page"
                : $"[ERROR] :: [{_featureContext.FeatureInfo.Title.ToUpper()}] :: Login Form Does Not Exist On Login Page");
        }

        [When]
        public void When_I_ENTER_A_RANDOM_EMAIL_ADDRESS_AND_PASSWORD_FROM_A_BDD_TABLE(Table credentialsTable)
        {
            List<User> tableData = (List<User>)credentialsTable.CreateSet<User>();

            var random = new Random();
            User randomUser = tableData[random.Next(tableData.Count - 1)];

            _parallelTestExecution.CurrentPage.AsPage<LoginPage>().EnterCredentials(randomUser.Email, randomUser.Password);
        }

        [When]
        public void When_I_ENTER_A_RANDOM_EMAIL_ADDRESS_AND_PASSWORD_FROM_A_SPREADSHEET()
        {
            string filePath = "Data" + Path.DirectorySeparatorChar + "CREDENTIALS.XLSX";
            DataTable credentials = new SpreadsheetDataHelpers.Spreadsheet(filePath).GetSheetByName("DATASET");
            DataColumnCollection cols = credentials.Columns;

            List<User> tableData = new List<User>();

            foreach (DataRow row in credentials.Rows)
            {
                tableData.Add(new User { Email = row.Field<string>("EMAIL"), Password = row.Field<string>("PASSWORD") });
            }

            var random = new Random();
            User randomUser = tableData[random.Next(tableData.Count - 1)];

            _parallelTestExecution.CurrentPage.AsPage<LoginPage>().EnterCredentials(randomUser.Email, randomUser.Password);
        }

        [When]
        public void When_I_CHOOSE_TO_REMEMBER_MY_CREDENTIALS()
        {
            // TODO: Implement This
        }

        [When]
        public void When_I_CLICK_THE_LOGIN_BUTTON()
        {
            _parallelTestExecution.CurrentPage = _parallelTestExecution.CurrentPage.AsPage<LoginPage>().ClickLoginButton();
        }

        [Then]
        public void Then_I_SHOULD_BE_AUTHENTICATED_AND_REDIRECTED_TO_THE_DASHBOARD()
        {
            // TODO: Implement This :: _parallelTestExecution.CurrentPage.AsPage<Dashboard>().AssertLogin();
        }
    }
}
