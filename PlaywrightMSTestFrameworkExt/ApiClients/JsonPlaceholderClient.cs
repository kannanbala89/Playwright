using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlaywrightMSTestFramework.ApiClients
{
    public class JsonPlaceholderClient
    {
        private readonly HttpClient _httpClient = new()
        {
            BaseAddress = new System.Uri("https://jsonplaceholder.typicode.com/")
        };

        public async Task<string> GetPostTitleAsync(int id)
        {
            var response = await _httpClient.GetAsync($"posts/{id}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(content);
            return jsonDoc.RootElement.GetProperty("title").GetString();
        }
    }
}
