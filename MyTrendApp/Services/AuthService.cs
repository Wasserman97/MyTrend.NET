
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyTrendApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AuthenticateAsync(string username, string password)
        {
            var authData = new { Username = username, Password = password };
            var content = new StringContent(JsonSerializer.Serialize(authData), Encoding.UTF8, "application/json");

            // Simulated endpoint for authentication
            var response = await _httpClient.PostAsync("https://external-auth-service.com/api/authenticate", content);

            return response.IsSuccessStatusCode;
        }
    }
}
