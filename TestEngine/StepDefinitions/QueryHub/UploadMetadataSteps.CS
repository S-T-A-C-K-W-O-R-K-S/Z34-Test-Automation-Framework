using FrameworkCore.Extensions;
using TechTalk.SpecFlow;
using TestEngine.Importware;
using ApplicationMap.Pages.QueryHub;
using NUnit.Framework;
using System.Threading.Tasks;
using TestEngine.StepDefinitions.Common;

namespace TestEngine.StepDefinitions.QueryHub
{
	[Binding]
	class UploadMetadataSteps : BaseStep
	{
		private new readonly FeatureContext FeatureContext;

		private HomePage HomePage;
		private UploadMetadataPage UploadMetadataPage;

		public UploadMetadataSteps(FeatureContext FeatureContext) : base(FeatureContext)
			=> this.FeatureContext = FeatureContext;

		[Given]
		public async Task GIVEN_I_NAVIGATE_TO_THE_METADATA_UPLOAD_PAGE()
		{
			HomePage = new HomePage(FeatureContext.GetPageInstance());
			await HomePage.NavigateToUploadMetadataPage();
			UploadMetadataPage = new UploadMetadataPage(FeatureContext.GetPageInstance());
		}

		[Given]
		public async Task GIVEN_I_CONFIRM_THAT_THE_METADATA_UPLOAD_SOURCE_IS_LOCAL()
			=> Warn.Unless(Equals("local", await UploadMetadataPage.UploadSource()), "Metadata Upload Source Is Local");

		[Given]
		public async Task GIVEN_I_CONFIRM_THAT_NO_WARNING_NOTIFICATIONS_EXIST()
			=> Warn.Unless(Equals(0, (await UploadMetadataPage.GetStagingAreaNotificationsCount()).Warning), "Warning Notification Count Is Zero");

		[When(@"I SELECT THE ""(.*)"" METADATA WORKFLOW")]
		public async Task WHEN_I_SELECT_THE_STRING_METADATA_WORKFLOW(string workflow)
			=> await UploadMetadataPage.SelectWorkflow(workflow);

		[When]
		public async Task WHEN_I_STAGE_ALL_AVOCADO_PRICES_METADATA_FILES_FOR_UPLOAD()
			=> await UploadMetadataPage.StageFiles(DataPaths.AvocadoPricesMetadata);

		[When]
		public async Task WHEN_I_CLICK_THE_UPLOAD_METADATA_BUTTON()
			=> await UploadMetadataPage.UploadStagedMetadata();

		[Then]
		public async Task THEN_I_CONFIRM_THAT_ALL_METADATA_FILES_HAVE_UPLOADED()
		{
			var (Success, Warning, Error) = UploadMetadataPage.FileUploadNotificationsCount;

			Assert.Multiple(() =>
			{
				Assert.NotZero(Success, "Success Notification Count");
				Assert.Zero(Warning, "Warning Notification Count");
				Assert.Zero(Error, "Error Notification Count");
			});

			await UploadMetadataPage.NavigateToHomePage();
		}
	}
}