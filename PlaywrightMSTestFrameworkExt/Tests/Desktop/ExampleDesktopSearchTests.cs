using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using PlaywrightMSTestFramework.Pages;

namespace PlaywrightMSTestFramework.Tests/Desktop
{
    [TestClass]
    public class ExampleDesktopSearchTests : UiTestBase
    {
        [TestMethod]
        public async Task DuckDuckGo_Search_ReturnsResults_Desktop()
        {
            var home = new HomePage(_page);
            await home.GoToAsync();
            _reportTest.Info("Navigated to DuckDuckGo");

            await home.SearchAsync("Playwright C# desktop");
            _reportTest.Info("Performed search");

            StringAssert.Contains(await _page.TitleAsync(), "Playwright");
        }
    }
}
