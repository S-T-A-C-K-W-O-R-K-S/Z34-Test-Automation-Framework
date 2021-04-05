using FrameworkCore.Extensions;
using TechTalk.SpecFlow;
using ApplicationMap.Pages.QueryHub;
using NUnit.Framework;
using System.Threading.Tasks;
using TestEngine.StepDefinitions.Common;

namespace TestEngine.StepDefinitions.QueryHub
{
	[Binding]
	class ValidateMetadataSteps : BaseStep
	{
		private new readonly FeatureContext FeatureContext;

		private HomePage HomePage;
		private WorkZoneStagingPage WorkZoneStagingPage;

		public ValidateMetadataSteps(FeatureContext FeatureContext) : base(FeatureContext)
			=> this.FeatureContext = FeatureContext;

		[Given]
		public async Task GIVEN_I_NAVIGATE_TO_THE_STAGING_AREA()
		{
			HomePage = new HomePage(FeatureContext.GetPageInstance());
			await HomePage.NavigateToStagingArea();

			WorkZoneStagingPage = new WorkZoneStagingPage(FeatureContext.GetPageInstance());
		}

		[When]
		public async Task WHEN_I_CLICK_THE_VALIDATE_BUTTON()
			=> await WorkZoneStagingPage.ValidateStagedObjects();

		[When]
		public async Task WHEN_I_CONFIRM_THAT_ALL_STAGED_OBJECTS_HAVE_BEEN_VALIDATED()
			=> Assert.IsTrue(await WorkZoneStagingPage.ValidatedSuccessfully(), "Staged Objects Have Been Validated");

		[When]
		public async Task WHEN_I_CLICK_THE_PUBLISH_BUTTON()
			=> await WorkZoneStagingPage.PublishStagedObjects();

		[Then]
		public async Task THEN_I_CONFIRM_THAT_ALL_STAGED_OBJECTS_HAVE_BEEN_PUBLISHED()
		{
			Assert.IsTrue(await WorkZoneStagingPage.PublishedSuccessfully(), "Staged Objects Have Been Published");
			await WorkZoneStagingPage.NavigateToHomePage();
		}
	}
}