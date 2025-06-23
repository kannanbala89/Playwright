using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using PlaywrightMSTestFramework.ApiClients;
using PlaywrightMSTestFramework.Reporting;

namespace PlaywrightMSTestFramework.Tests.Api
{
    [TestClass]
    public class ExampleApiTests
    {
        private readonly JsonPlaceholderClient _client = new();
        private AventStack.ExtentReports.ExtentTest _reportTest;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Setup()
        {
            _reportTest = ReportManager.Instance.CreateTest(TestContext.TestName).AssignCategory("API");
        }

        [TestMethod]
        public async Task GetPostTitle_ReturnsExpectedTitle()
        {
            _reportTest.Info("Fetching post title from API");
            var title = await _client.GetPostTitleAsync(1);
            StringAssert.Contains(title.ToLower(), "sunt aut facere");
            _reportTest.Pass("API validation passed");
        }
    }
}
