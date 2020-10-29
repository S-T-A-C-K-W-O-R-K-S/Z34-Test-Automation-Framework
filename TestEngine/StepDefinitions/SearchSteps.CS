using ApplicationMap.Pages;
using Atata;
using TechTalk.SpecFlow;

namespace TestEngine.StepDefinitions
{
    public sealed class SearchSteps : BaseStep
    {
        [Given]
        public void GIVEN_I_NAVIGATE_TO_THE_DASHBOARD()
        {
            Go.To<SearchPage>();
        }

        [Given(@"I CONFIRM THAT THE PAGE TITLE CONTAINS ""(.*)""")]
        public void GIVEN_I_CONFIRM_THAT_THE_PAGE_TITLE_CONTAINS_STRING(string substring)
        {
            On<SearchPage>().PageTitle.Should.Contain(substring);
        }

        [When(@"I ENTER THE TEXT ""(.*)"" IN THE SEARCH BAR")]
        public void WHEN_I_ENTER_THE_TEXT_STRING_IN_THE_SEARCH_BAR(string term)
        {
            On<SearchPage>().SearchBar.Set(term);
        }

        [Then(@"THE TEXT IN THE SEARCH BAR SHOULD BE ""(.*)""")]
        public void THEN_THE_TEXT_IN_THE_SEARCH_BAR_SHOULD_BE_STRING(string term)
        {
            On<SearchPage>()
                .SearchBar.Set(term)
                .SearchBar.Should.Equal(term)
                .Report.Screenshot();
        }
    }
}