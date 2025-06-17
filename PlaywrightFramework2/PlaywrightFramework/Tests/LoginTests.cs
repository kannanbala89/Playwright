using NUnit.Framework;
using Microsoft.Playwright;
using PlaywrightFramework.Drivers;
using PlaywrightFramework.Pages;

namespace PlaywrightFramework.Tests
{
    public class LoginTests
    {
        private PlaywrightDriver _driver;
        private IPage _page;

        [SetUp]
        public async Task Setup()
        {
            _driver = new PlaywrightDriver();
            _page = await _driver.InitAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _driver.CleanupAsync();
        }

        [Test]
        public async Task ValidUserCanLogin()
        {
            var loginPage = new LoginPage(_page);
            await loginPage.NavigateAsync();
            await loginPage.LoginAsync("user", "pass");

            Assert.IsTrue(await loginPage.IsLoggedInAsync());
        }
    }
}