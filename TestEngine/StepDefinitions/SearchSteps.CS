using ApplicationMap.Pages;
using Atata;
using TechTalk.SpecFlow;

namespace TestEngine.StepDefinitions
{
    public sealed class SearchSteps : BaseSteps
    {
        [When(@"I SEARCH FOR THE TEXT ""(.*)""")]
        public void When_I_SEARCH_FOR_THE_TEXT_TERM(string term)
        {
            On<SearchPage>().SearchBar.Set(term);
        }

        [Then(@"THE TEXT IN THE SEARCH BAR SHOULD BE ""(.*)""")]
        public void Then_THE_TEXT_IN_THE_SEARCH_BAR_SHOULD_BE_TERM(string term)
        {
            On<SearchPage>()
                .SearchBar.Set(term)
                .SearchBar.Should.Equal(term)
                .Report.Screenshot();
        }
    }
}