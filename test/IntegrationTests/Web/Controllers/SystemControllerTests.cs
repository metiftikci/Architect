using Xunit;

namespace Architect.IntegrationTests.Web.Controllers
{
    public class SystemControllerTests : ControllerTestsBase
    {
        public SystemControllerTests(TestWebApplicationFactory webApplicationFactory) : base(webApplicationFactory) { }

        [Fact]
        public async void GetVersionTest()
        {
            var response = await CreateClient().GetAsync("api/system/version");

            response.EnsureSuccessStatusCode();

            var version = await response.Content.ReadAsStringAsync();

            Assert.False(string.IsNullOrWhiteSpace(version));
        }
    }
}
