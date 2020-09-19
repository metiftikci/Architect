using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Architect.Web.Models;
using Xunit;

namespace Architect.IntegrationTests.Web.Controllers
{
    public abstract class ControllerTestsBase : IClassFixture<TestWebApplicationFactory>
    {
        protected readonly TestWebApplicationFactory WebApplicationFactory;

        public ControllerTestsBase(TestWebApplicationFactory webApplicationFactory) => WebApplicationFactory = webApplicationFactory;

        protected HttpClient CreateClient()
        {
            return WebApplicationFactory.CreateClient();
        }

        protected async Task<HttpClient> CreateAuthenticatedClientAsync()
        {
            var client = CreateClient();

            var body = new { Username = "admin", Password = "123456" };

            var response = await client.PostAsync("api/users/authenticate", JsonContent(body));

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var authResponse = Deserialize<AuthenticateResponse>(json);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResponse.Token);

            return client;
        }

        protected async Task<TValue> SendAsAuthenticatedAndDeserializeAsync<TValue>(string uri)
            => await SendAsAuthenticatedAndDeserializeAsync<TValue>(uri, HttpMethod.Get, null);

        protected async Task<TValue> SendAsAuthenticatedAndDeserializeAsync<TValue>(string uri, HttpMethod method)
            => await SendAsAuthenticatedAndDeserializeAsync<TValue>(uri, method, null);

        protected async Task<TValue> SendAsAuthenticatedAndDeserializeAsync<TValue>(string uri, HttpMethod method, object body)
        {
            var client = await CreateAuthenticatedClientAsync();

            var content = body == null ? null : JsonContent(body);

            var response = await client.SendAsync(new HttpRequestMessage(method, uri) { Content = content });

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return Deserialize<TValue>(json);
        }

        protected StringContent JsonContent(object body) => new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

        protected TValue Deserialize<TValue>(string json)
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            return JsonSerializer.Deserialize<TValue>(json, options);
        }
    }
}
