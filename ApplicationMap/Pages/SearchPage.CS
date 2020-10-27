using Atata;

namespace ApplicationMap.Pages
{
    using _ = SearchPage;

    public class SearchPage : Page<_>
    {
        [FindById("searchBar")] public SearchInput<_> SearchBar { get; private set; }

        [FindById("searchButton")] public Button<_> SearchButton { get; private set; }
    }
}