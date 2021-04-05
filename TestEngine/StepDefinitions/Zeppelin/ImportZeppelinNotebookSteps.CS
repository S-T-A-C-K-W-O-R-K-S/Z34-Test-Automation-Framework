using ApplicationMap.Pages.QueryHub;
using ApplicationMap.Pages.Zeppelin;
using FrameworkCore.Extensions;
using NUnit.Framework;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestEngine.Importware;
using TestEngine.StepDefinitions.Common;

namespace TestEngine.StepDefinitions.Zeppelin
{
	[Binding]
	class ImportZeppelinNotebookSteps : BaseStep
	{
		private new readonly FeatureContext FeatureContext;

		private HomePage HomePage;
		private ZeppelinHomePage ZeppelinHomePage;

		public ImportZeppelinNotebookSteps(FeatureContext FeatureContext) : base(FeatureContext)
			=> this.FeatureContext = FeatureContext;

		[Given]
		public async Task GIVEN_I_NAVIGATE_TO_ZEPPELIN()
		{
			HomePage = new HomePage(FeatureContext.GetPageInstance());
			await HomePage.NavigateToZeppelin(FeatureContext);

			ZeppelinHomePage = new ZeppelinHomePage(FeatureContext.GetPageInstance());
		}

		[Given]
		public async Task GIVEN_I_CONFIRM_THAT_I_AM_LOGGED_INTO_ZEPPELIN_AS_THE_SELECTED_USER()
			=> Assert.AreEqual(FeatureContext.GetUser().Username.Flatten(),
				(await ZeppelinHomePage.GetLoggedInUserName()).Flatten(), "Zeppelin Logged In User");

		[When(@"I IMPORT THE ""(.*)"" NOTEBOOK")]
		public async Task WHEN_I_IMPORT_THE_STRING_NOTEBOOK(string notebook)
			=> await ZeppelinHomePage.ImportNotebook(DataPaths.AvocadoPricesNotebook, notebook);

		[Then(@"I CONFIRM THAT THE ""(.*)"" NOTEBOOK HAS BEEN IMPORTED")]
		public async Task THEN_I_CONFIRM_THAT_THE_STRING_NOTEBOOK_HAS_BEEN_IMPORTED(string notebook)
			=> Assert.IsTrue(await ZeppelinHomePage.NotebookExists(notebook), "Notebook Exists");
	}
}