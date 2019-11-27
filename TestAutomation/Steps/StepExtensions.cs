﻿using FrameworkCore.Base;
using FrameworkCore.Config;
using FrameworkCore.Extensions;
using FrameworkCore.Helpers;
using TechTalk.SpecFlow;
using TestAutomation.Pages;

namespace TestAutomation.Steps
{
    [Binding]
    public class StepExtensions : BaseStep
    {
        private readonly ParallelTestExecution _parallelTestExecution;

        public StepExtensions (ParallelTestExecution parallelTestExecution) : base (parallelTestExecution)
        {
            _parallelTestExecution = parallelTestExecution;
        }

        [Given]
        public void Given_I_HAVE_NAVIGATED_TO_THE_APPLICATION()
        {
            NavigateToAUT();
            _parallelTestExecution.CurrentPage = new HomePage(_parallelTestExecution);
        }

        [Given(@"I DELETE EMPLOYEE ""(.*)"" PRIOR TO RUNNING TEST")]
        public void Given_I_DELETE_EMPLOYEE_PRIOR_TO_RUNNING_TEST(string employeeName)
        {
            string query = "DELETE FROM Employees WHERE NAME = '" + employeeName + "'";
            Settings.DatabaseConnection.ExecuteQuery(query);
        }

        public void NavigateToAUT()
        {
            _parallelTestExecution.Driver.Navigate().GoToUrl(Settings.AUT);
            LogHelpers.WriteToLog($"Navigating To Page :: {Settings.AUT}");
            _parallelTestExecution.Driver.WaitForPageLoaded();
            LogHelpers.WriteToLog($"DOM On Page Fully Loaded :: {Settings.AUT}");
        }
    }
}