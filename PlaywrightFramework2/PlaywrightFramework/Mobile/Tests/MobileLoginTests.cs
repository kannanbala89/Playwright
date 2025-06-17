using NUnit.Framework;
using Microsoft.Playwright;
using PlaywrightFramework.Drivers;
using PlaywrightFramework.Pages;

namespace PlaywrightFramework.Mobile.Tests
{
    public class MobileLoginTests
    {
        private PlaywrightDriver _driver;
        private IPage _page;

        [SetUp]
        public async Task Setup()
        {
            _driver = new PlaywrightDriver();
            var contextOptions = new BrowserNewContextOptions
            {
                ViewportSize = new() { Width = 375, Height = 812 },
                UserAgent = "Mozilla/5.0 (iPhone; CPU iPhone OS 13_6 like Mac OS X)..."
            };
            var context = await (await Microsoft.Playwright.Playwright.CreateAsync()).Chromium.LaunchPersistentContextAsync("", new BrowserTypeLaunchPersistentContextOptions
            {
                Headless = true,
                ViewportSize = contextOptions.ViewportSize,
                UserAgent = contextOptions.UserAgent
            });
            _page = await context.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _page.Context.CloseAsync();
        }

        [Test]
        public async Task MobileUserCanLogin()
        {
            var loginPage = new LoginPage(_page);
            await loginPage.NavigateAsync();
            await loginPage.LoginAsync("user", "pass");
            Assert.IsTrue(await loginPage.IsLoggedInAsync());
        }
    }
}