using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Webenable.Logging.JavaScript.Tests
{
    public class SnippetTests : IClassFixture<WebApplicationFactory<TestWebsite.Startup>>
    {
        private readonly WebApplicationFactory<TestWebsite.Startup> _factory;

        public SnippetTests(WebApplicationFactory<TestWebsite.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task RendersSippet()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            Assert.Contains("<script type=\"text/javascript\">function logToServer(n,t){$.post(\"/log\"", body);
        }
    }
}
