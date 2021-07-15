using System.Dynamic;
using System.Net;
using System.Threading.Tasks;
using WebApi;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests
{
    
    public class UserControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        private readonly ITestOutputHelper _output;

        public UserControllerTests(CustomWebApplicationFactory<Startup> factory, ITestOutputHelper output)
        {
            _factory = factory;
            _output = output;
        }


        [Fact]
        public async Task GetUsers_ShouldReturnOk()
        {
            dynamic data = GetCustomToken();
            
            // Arrange
            var client = _factory.CreateClient();
            client.SetFakeBearerToken((object) data);
            
            // Act
            var response = await client.GetAsync("/api/users");
            _output.WriteLine(await response.Content.ReadAsStringAsync());
            

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Fact]
        public async Task GetUsers_ShouldReturnUnauthorized()
        {
            dynamic data = GetCustomToken();
            
            // Arrange
            var client = _factory.CreateClient();
            
            // Act
            var response = await client.GetAsync("/api/users");
            _output.WriteLine(await response.Content.ReadAsStringAsync());
            

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
        
        private static dynamic GetCustomToken()
        {
            dynamic data = new ExpandoObject();
            data.sub = "bc29cfa0-3d09-4d8c-9481-2e8c0eb1aa6c";
            data.extension_UserRole = "Customer";
            data.extension_UserType = "Customer";
            return data;
        }
        
    }
}