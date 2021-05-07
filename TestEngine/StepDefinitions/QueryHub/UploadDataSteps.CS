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
	class UploadDataSteps : BaseStep
	{
		private new readonly FeatureContext FeatureContext;

		private HomePage HomePage;
		private UploadDataPage UploadDataPage;

		public UploadDataSteps(FeatureContext FeatureContext) : base(FeatureContext)
			=> this.FeatureContext = FeatureContext;

		[Given]
		public async Task GIVEN_I_NAVIGATE_TO_THE_DATA_UPLOAD_PAGE()
		{
			HomePage = new HomePage(FeatureContext.GetPageInstance());
			await HomePage.NavigateToUploadDataPage();
			UploadDataPage = new UploadDataPage(FeatureContext.GetPageInstance());
		}

		[Given]
		public async Task GIVEN_I_CONFIRM_THAT_THE_DATA_UPLOAD_SOURCE_IS_LOCAL()
			=> Warn.Unless(Equals("local", await UploadDataPage.UploadSource()), "Data Upload Source Is Local");

		[When(@"I SELECT THE ""(.*)"" DATA WORKFLOW")]
		public async Task WHEN_I_SELECT_THE_STRING_DATA_WORKFLOW(string workflow)
			=> await UploadDataPage.SelectWorkflow(workflow);

		[When]
		public async Task WHEN_I_STAGE_ALL_AVOCADO_PRICES_DATA_FILES_FOR_UPLOAD()
			=> await UploadDataPage.StageFiles(DataPaths.AvocadoPricesData);

		[When]
		public async Task WHEN_I_CLICK_THE_UPLOAD_DATA_BUTTON()
			=> await UploadDataPage.UploadStagedData();

		[Then]
		public async Task THEN_I_CONFIRM_THAT_ALL_DATA_FILES_HAVE_UPLOADED()
		{
			var (Success, Warning, Error) = UploadDataPage.FileUploadNotificationsCount;

			Assert.Multiple(() =>
			{
				Assert.NotZero(Success, "Success Notification Count");
				Assert.Zero(Warning, "Warning Notification Count");
				Assert.Zero(Error, "Error Notification Count");
			});

			await UploadDataPage.NavigateToHomePage();
		}
	}
}