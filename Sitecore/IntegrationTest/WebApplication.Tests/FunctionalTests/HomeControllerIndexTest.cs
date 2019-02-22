using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApplication.Tests.FunctionalTests
{
    public class HomeControllerIndexTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }
        public WebApplicationFactory<Startup> Server { get; }

        public HomeControllerIndexTest(WebApplicationFactory<Startup> server)
        {
            Client = server.CreateClient();
            Server = server;
        }

        [Fact]
        public async Task GetHomePage()
        {
            // Arrange & Act
            var response = await Client.GetAsync("/");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
