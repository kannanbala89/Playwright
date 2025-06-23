using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using PlaywrightMSTestFramework.Drivers;
using PlaywrightMSTestFramework.Reporting;
using AventStack.ExtentReports;

namespace PlaywrightMSTestFramework.Tests
{
    [TestClass]
    public abstract class UiTestBase
    {
        protected IBrowserContext _context;
        protected IPage _page;
        protected ExtentTest _reportTest;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public async Task SetupAsync()
        {
            _context = await PlaywrightDriver.GetContextAsync();
            _page = await _context.NewPageAsync();

            _reportTest = ReportManager.Instance
                .CreateTest(TestContext.TestName)
                .AssignCategory("UI");
        }

        [TestCleanup]
        public async Task CleanupAsync()
        {
            var result = TestContext.CurrentTestOutcome;

            if (result != UnitTestOutcome.Passed)
            {
                var screenshotPath = $"{TestContext.TestRunDirectory}\{TestContext.TestName}.png";
                await _page.ScreenshotAsync(new PageScreenshotOptions { Path = screenshotPath, FullPage = true });
                _reportTest.Fail("Test failed").AddScreenCaptureFromPath(screenshotPath);
            }
            else
            {
                _reportTest.Pass("Test passed");
            }

            await _context.CloseAsync();
        }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // Nothing required here yet
        }

        [AssemblyCleanup]
        public static async Task GlobalCleanupAsync()
        {
            ReportManager.Instance.Flush();
            await PlaywrightDriver.DisposeAsync();
        }
    }
}
