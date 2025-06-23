using Microsoft.Playwright;
using PlaywrightMSTestFramework.DeviceProfiles;
using System.Threading.Tasks;

namespace PlaywrightMSTestFramework.Drivers
{
    public static class PlaywrightDriver
    {
        private static IPlaywright _playwright;
        private static IBrowser _browser;

        public static async Task<IBrowser> GetBrowserAsync()
        {
            if (_browser is not null) return _browser;

            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });

            return _browser;
        }

        public static async Task<IBrowserContext> GetContextAsync(string profileName = null)
        {
            var browser = await GetBrowserAsync();

            if (!string.IsNullOrEmpty(profileName) && DeviceLibrary.Profiles.TryGetValue(profileName, out var device))
            {
                return await browser.NewContextAsync(new BrowserNewContextOptions(device));
            }

            return await browser.NewContextAsync();
        }

        public static async Task DisposeAsync()
        {
            if (_browser is not null)
            {
                await _browser.CloseAsync();
                _playwright.Dispose();
                _browser = null;
                _playwright = null;
            }
        }
    }
}
