using System.Linq;
using Architect.Infrastructure.Data;
using Architect.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Architect.IntegrationTests.Web
{
    public class TestWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.FirstOrDefault(d => d.ServiceType == typeof(DbContextOptions<ArchitectDbContext>));

                services.Remove(dbContextDescriptor);

                services.AddDbContext<ArchitectDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
            });
        }
    }
}
