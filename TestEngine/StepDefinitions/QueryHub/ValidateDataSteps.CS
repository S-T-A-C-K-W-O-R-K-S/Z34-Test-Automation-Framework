using System.Threading.Tasks;
using ApplicationMap.Pages.QueryHub;
using FrameworkCore.Extensions;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestEngine.StepDefinitions.Common;

namespace TestEngine.StepDefinitions.QueryHub
{
    [Binding]
    internal class ValidateDataSteps : BaseStep
    {
        private new readonly FeatureContext FeatureContext;

        private HomePage HomePage;
        private WorkZoneInBasketPage WorkZoneInBasketPage;

        public ValidateDataSteps(FeatureContext FeatureContext) : base(FeatureContext)
        {
            this.FeatureContext = FeatureContext;
        }

        [Given]
        public async Task GIVEN_I_NAVIGATE_TO_THE_IN_BASKET()
        {
            HomePage = new HomePage(FeatureContext.GetPageInstance());
            await HomePage.NavigateToInBasket();

            WorkZoneInBasketPage = new WorkZoneInBasketPage(FeatureContext.GetPageInstance());
        }

        [Given(@"I CONFIRM THAT A BATCH OF TYPE ""(.*)"" EXISTS")]
        public async Task GIVEN_I_CONFIRM_THAT_A_BATCH_OF_TYPE_STRING_EXISTS(string batch)
        {
            Assert.AreEqual(batch, await WorkZoneInBasketPage.GetBatchType(batch), "Batch Name");
        }

        [Then(@"I CONFIRM THAT THE BATCH ""(.*)"" COMPLETED WITH NO STEP ERRORS")]
        public async Task THEN_I_CONFIRM_THAT_THE_BATCH_STRING_COMPLETED_WITH_NO_STEP_ERRORS(string batch)
        {
            Assert.IsTrue(await WorkZoneInBasketPage.DataIngestedSuccessfully(batch), "No Step Errors");
            await WorkZoneInBasketPage.NavigateToHomePage();
        }
    }
}