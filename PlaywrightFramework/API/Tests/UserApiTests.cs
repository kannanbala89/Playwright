using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using PlaywrightFramework.API.Clients;

namespace PlaywrightFramework.API.Tests
{
    public class UserApiTests
    {
        private UserClient _userClient;

        [SetUp]
        public void Setup()
        {
            var httpClient = new HttpClient { BaseAddress = new System.Uri("https://example.com") };
            _userClient = new UserClient(httpClient);
        }

        [Test]
        public async Task LoginApi_ShouldReturnSuccess()
        {
            var response = await _userClient.LoginAsync("user", "pass");
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}