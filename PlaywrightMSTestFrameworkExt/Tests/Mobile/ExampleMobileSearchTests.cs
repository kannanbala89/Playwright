using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using PlaywrightMSTestFramework.Drivers;
using PlaywrightMSTestFramework.Pages;
using PlaywrightMSTestFramework.DeviceProfiles;
using PlaywrightMSTestFramework.Reporting;

namespace PlaywrightMSTestFramework.Tests.Mobile
{
    [TestClass]
    public class ExampleMobileSearchTests
    {
        private IBrowserContext _context;
        private IPage _page;
        private AventStack.ExtentReports.ExtentTest _reportTest;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public async Task SetupAsync()
        {
            _context = await PlaywrightDriver.GetContextAsync("iPhone 13 Pro");
            _page = await _context.NewPageAsync();
            _reportTest = ReportManager.Instance.CreateTest(TestContext.TestName).AssignCategory("Mobile");
        }

        [TestMethod]
        public async Task DuckDuckGo_Search_ReturnsResults_Mobile()
        {
            var home = new HomePage(_page);
            await home.GoToAsync();
            _reportTest.Info("Navigated to DuckDuckGo (mobile)");

            await home.SearchAsync("Playwright mobile emulation");
            _reportTest.Info("Performed search");

            StringAssert.Contains(await _page.TitleAsync(), "Playwright");
        }

        [TestCleanup]
        public async Task CleanupAsync()
        {
            var result = TestContext.CurrentTestOutcome;
            if (result != UnitTestOutcome.Passed)
            {
                var screenshot = $"{TestContext.TestRunDirectory}\{TestContext.TestName}_mobile.png";
                await _page.ScreenshotAsync(new() { Path = screenshot, FullPage = true });
                _reportTest.Fail("Test failed").AddScreenCaptureFromPath(screenshot);
            }
            else
            {
                _reportTest.Pass("Test passed");
            }

            await _context.CloseAsync();
        }
    }
}
