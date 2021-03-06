﻿using ApplicationMap.Pages;
using FrameworkCore.Base;
using FrameworkCore.Models;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TestRunner.Steps
{
    [Binding]
    public class HTMLTableSteps : BaseStep
    {
        private readonly FeatureContext _featureContext;
        private readonly ParallelTestExecution _parallelTestExecution;

        public HTMLTableSteps(ParallelTestExecution parallelTestExecution, FeatureContext featureContext) : base(parallelTestExecution)
        {
            _parallelTestExecution = parallelTestExecution;
            _featureContext = featureContext;
        }

        private StepExtensions StepExtensions => new StepExtensions(_parallelTestExecution, _featureContext);

        [Given]
        public void Given_I_NAVIGATE_TO_THE_TABLES_PAGE()
        {
            StepExtensions.NavigateToPage("tables.html");
            _parallelTestExecution.CurrentPage = new TablesPage(_parallelTestExecution);
        }

        [Given]
        public void Given_I_CONFIRM_THAT_THE_TABLE_IS_DISPLAYED_ON_THE_PAGE()
        {
            Assert.IsTrue(_parallelTestExecution.CurrentPage.AsPage<TablesPage>().TableStaffData.Displayed);
        }

        [When(@"I NAVIGATE TO THE TABLE (.*)")]
        public void When_I_NAVIGATE_TO_THE_TABLE_TAB(string tab)
        {
            _parallelTestExecution.CurrentPage.AsPage<TablesPage>().NavigateToTableTab(tab);
        }

        [Then(@"STAFF MEMBER ""(.*)"" SHOULD HAVE ""(.*)""")]
        public void Then_STAFF_MEMBER_SHOULD_HAVE_POSITION(string name, string position)
        {
            HTMLTable table = _parallelTestExecution.CurrentPage.AsPage<TablesPage>().GetParsedTable();

            bool match = false;

            foreach (Row row in table.Body)
            {
                // TODO: Use Parsed Header Names Instead Of Cell List Index
                if (row.Cells[0].Self.InnerText == name && row.Cells[1].Self.InnerText == position)
                    match = true;
            }

            Assert.IsTrue(match);
        }
    }
}
