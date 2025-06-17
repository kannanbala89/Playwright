using Microsoft.Playwright;

namespace PlaywrightFramework.Drivers
{
    public class PlaywrightDriver
    {
        public IPlaywright Playwright { get; private set; }
        public IBrowser Browser { get; private set; }
        public IBrowserContext Context { get; private set; }
        public IPage Page { get; private set; }

        public async Task<IPage> InitAsync(bool headless = true)
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = headless });
            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();
            return Page;
        }

        public async Task CleanupAsync()
        {
            await Context?.CloseAsync();
            await Browser?.CloseAsync();
            Playwright?.Dispose();
        }
    }
}