using Microsoft.Playwright;

namespace PlaywrightFramework.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page) => _page = page;

        public async Task NavigateAsync() => await _page.GotoAsync("https://example.com/login");

        public async Task LoginAsync(string username, string password)
        {
            await _page.FillAsync("#username", username);
            await _page.FillAsync("#password", password);
            await _page.ClickAsync("#login");
        }

        public async Task<bool> IsLoggedInAsync()
        {
            await _page.WaitForURLAsync("**/dashboard");
            return _page.Url.Contains("dashboard");
        }
    }
}