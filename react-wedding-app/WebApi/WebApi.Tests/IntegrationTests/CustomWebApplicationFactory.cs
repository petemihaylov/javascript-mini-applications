using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using WebApi;
using WebMotions.Fake.Authentication.JwtBearer;

namespace IntegrationTests
{
    public class CustomWebApplicationFactory<TStart> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseTestServer().ConfigureTestServices(collection =>
            {
                collection.AddAuthentication(FakeJwtBearerDefaults.AuthenticationScheme).AddFakeJwtBearer();
            });
        }
    }
}