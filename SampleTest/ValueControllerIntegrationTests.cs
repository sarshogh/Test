using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Sample;
using Sample.RequestsResponses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace SampleTest
{
    public class ValueControllerIntegrationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ValueControllerIntegrationTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetUsreInfo()
        {
            var client = _factory.CreateClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var req = new GetMyInfoRequest
            {
                UserId = 1
            };

            var response = await client.PostAsJsonAsync("api/v1/Values/get-my-info", req);

            // Must be successful.
            response.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await response.Content.ReadAsStringAsync();

            //Assert.Equal("text/html; charset=utf-8", response.Content.Headers.ContentType.ToString());
            var dataRes = JsonConvert.DeserializeObject<GetMyInfoResponse>(stringResponse);
            Assert.Equal("ali", dataRes.UserName);
        }
    }
}
