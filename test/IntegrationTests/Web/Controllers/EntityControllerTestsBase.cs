using System.Threading.Tasks;
using Xunit;
using Architect.ApplicationCore.Models;
using System.Net.Http;

namespace Architect.IntegrationTests.Web.Controllers
{
    public abstract class EntityControllerTestsBase<TModel> : ControllerTestsBase
        where TModel : class, IEntity, new()
    {
        protected EntityControllerTestsBase(TestWebApplicationFactory webApplicationFactory) : base(webApplicationFactory) { }

        [Fact]
        public async Task FindAsync()
        {
            var model = await SendAndDeserializeAsync<TModel>($"/api/{typeof(TModel).Name}s/1");

            Assert.NotNull(model);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public async Task InsertAsync_non_authenticated()
        {
            var entity = new TModel();

            var statusCode = await SendAndDeserializeAsync<int>($"/api/{typeof(TModel).Name}s", HttpMethod.Post, entity);

            Assert.Equal(401, statusCode);
        }

        [Fact]
        public async Task InsertAsync_authenticated()
        {
            var entity = new TModel();

            var statusCode = await SendAsAuthenticatedAndDeserializeAsync<int>($"/api/{typeof(TModel).Name}s", HttpMethod.Post, entity);

            Assert.Equal(201, statusCode);

            var insertedEntity = await SendAsAuthenticatedAndDeserializeAsync<TModel>($"/api/{typeof(TModel).Name}s/2");

            Assert.NotNull(insertedEntity);
            Assert.Equal(2, insertedEntity.Id);
        }

        [Fact]
        public async Task UpdateAsync_non_authenticated()
        {
            var entity = new TModel();

            var statusCode = await SendAndDeserializeAsync<int>($"/api/{typeof(TModel).Name}s", HttpMethod.Patch, entity);

            Assert.Equal(401, statusCode);
        }

        [Fact]
        public async Task UpdateAsync_authenticated()
        {
            var entity = new TModel();

            var statusCode = await SendAsAuthenticatedAndDeserializeAsync<int>($"/api/{typeof(TModel).Name}s", HttpMethod.Patch, entity);

            Assert.Equal(200, statusCode);

            var insertedEntity = await SendAsAuthenticatedAndDeserializeAsync<TModel>($"/api/{typeof(TModel).Name}s/1");

            Assert.NotNull(insertedEntity);
            Assert.Equal(1, insertedEntity.Id);
        }

        [Fact]
        public async Task DeleteAsync_non_authenticated()
        {
            var statusCode = await SendAndDeserializeAsync<int>($"/api/{typeof(TModel).Name}s/1", HttpMethod.Delete);

            Assert.Equal(401, statusCode);
        }

        [Fact]
        public async Task DeleteAsync_authenticated()
        {
            var statusCode = await SendAsAuthenticatedAndDeserializeAsync<int>($"/api/{typeof(TModel).Name}s/1", HttpMethod.Delete);

            Assert.Equal(204, statusCode);
        }
    }
}
