using Microsoft.Playwright;
using System.Threading.Tasks;

namespace PlaywrightMSTestFramework.Pages
{
    public class HomePage
    {
        private readonly IPage _page;

        public HomePage(IPage page) => _page = page;

        private ILocator SearchInput => _page.Locator("input[name='q']");
        private ILocator SearchButton => _page.Locator("input[type='submit']");

        public async Task GoToAsync() => await _page.GotoAsync("https://duckduckgo.com");

        public async Task SearchAsync(string query)
        {
            await SearchInput.FillAsync(query);
            await SearchButton.ClickAsync();
        }
    }
}
