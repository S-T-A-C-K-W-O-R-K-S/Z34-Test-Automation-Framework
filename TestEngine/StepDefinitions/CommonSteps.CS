using ApplicationMap.Pages;
using Atata;
using TechTalk.SpecFlow;

namespace TestEngine.StepDefinitions
{
    public sealed class CommonSteps : BaseSteps
    {
        [Given]
        public void Given_I_NAVIGATE_TO_THE_DASHBOARD()
        {
            Go.To<SearchPage>();
        }

        [Given(@"I CONFIRM THAT THE PAGE TITLE CONTAINS ""(.*)""")]
        public void Given_I_CONFIRM_THAT_THE_PAGE_TITLE_CONTAINS_SUBSTRING(string substring)
        {
            On<SearchPage>().PageTitle.Should.Contain(substring);
        }
    }
}