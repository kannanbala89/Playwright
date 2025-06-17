using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PlaywrightFramework.API.Clients
{
    public class UserClient
    {
        private readonly HttpClient _httpClient;

        public UserClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> LoginAsync(string username, string password)
        {
            var request = new { username, password };
            return await _httpClient.PostAsJsonAsync("/api/login", request);
        }
    }
}