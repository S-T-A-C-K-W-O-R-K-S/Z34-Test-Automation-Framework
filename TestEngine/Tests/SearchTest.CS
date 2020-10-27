using ApplicationMap.Pages;
using Atata;
using NUnit.Framework;
using TestEngine.FixtureConfiguration;

namespace TestEngine.Tests
{
    public class SearchTest : UITestFixture
    {
        [Test]
        public void SearchBar()
        {
            var bar = "bar";

            Go.To<SearchPage>()
                .PageTitle.Should.Contain("WebOasis")
                .SearchBar.Set(bar)
                .AggregateAssert(page => page
                    .SearchButton.Content.Should.Equal("Find")
                    .SearchBar.Should.Equal(bar))
                .Report.Screenshot();
        }

        [Test]
        public void SearchFoo()
        {
            var foo = "foo";

            Go.To<SearchPage>()
                .Report.Screenshot()
                .PageTitle.Should.Contain("WebOasis")
                .SearchBar.Set(foo)
                .SearchButton.Content.Should.Equal("Find")
                .SearchBar.Should.Equal(foo);
        }
    }
}