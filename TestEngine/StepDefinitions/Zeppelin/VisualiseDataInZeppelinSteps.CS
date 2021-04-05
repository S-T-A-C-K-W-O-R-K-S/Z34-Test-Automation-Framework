using ApplicationMap.Pages.Zeppelin;
using FrameworkCore.Extensions;
using NUnit.Framework;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestEngine.StepDefinitions.Common;

namespace TestEngine.StepDefinitions.Zeppelin
{
	[Binding]
	class VisualiseDataInZeppelinSteps : BaseStep
	{
		private new readonly FeatureContext FeatureContext;

		private ZeppelinHomePage ZeppelinHomePage;
		private ZeppelinNotebookPage ZeppelinNotebookPage;

		public VisualiseDataInZeppelinSteps(FeatureContext FeatureContext) : base(FeatureContext)
			=> this.FeatureContext = FeatureContext;

		[Given(@"I AM ON THE PAGE WITH THE TITLE ""(.*)""")]
		public async Task GIVEN_I_AM_ON_THE_PAGE_WITH_THE_TITLE_STRING(string title)
		{
			ZeppelinHomePage = new ZeppelinHomePage(FeatureContext.GetPageInstance());
			Assert.AreEqual(title, await ZeppelinHomePage.Self.GetTitleAsync(), "Zeppelin Home Page Title");
		}

		[When(@"I OPEN THE ""(.*)"" NOTEBOOK")]
		public async Task WHEN_I_OPEN_THE_STRING_NOTEBOOK(string notebook)
		{
			await ZeppelinHomePage.OpenNotebook(notebook);
			ZeppelinNotebookPage = new ZeppelinNotebookPage(FeatureContext.GetPageInstance());
		}

		[When]
		public async Task WHEN_I_RUN_ALL_NOTEBOOK_PARAGRAPHS()
			=> await ZeppelinNotebookPage.RunAllParagraphs();

		[Then]
		public async Task THEN_I_CONFIRM_THAT_ALL_PARAGRAPHS_HAVE_EXECUTED_SUCCESSFULLY()
			=> Assert.True(await ZeppelinNotebookPage.ParagraphsExecutedSuccessfully(), "All Paragraphs Have Executed Successfully");
	}
}