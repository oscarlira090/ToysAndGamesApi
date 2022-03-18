using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using StockManagementEntities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ToysAndGamesTesting
{
    public class ProductIntegrationTest
    {
        protected readonly HttpClient _client;

        public ProductIntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Program>();
            _client = appFactory.CreateClient();
        }

        [Fact]
        [Trait ("Category", "IntegrationTest")]
        public async Task Get_ReturnAllProducts()
        {
            var response = await _client.GetAsync("/api/Product");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<Product>>(content);
            Assert.True(products.Count > 0);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        [Trait("Category", "IntegrationTest")]
        public async Task GetByIdProduct_ReturnProductNotFound()
        {
            int productId = 0;
            var response = await _client.GetAsync($"/api/Product/{productId}");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        [Trait("Category", "IntegrationTest")]
        public async Task GetByIdProduct_ReturnProductFound()
        {
            int productId = 1;
            var response = await _client.GetAsync($"/api/Product/{productId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(content);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(product);
        }

        [Theory]
        [Trait("Category", "IntegrationTest")]
        [ProductDataAttribute]
        public async Task Post_CreateReturnCreatedProduct(FormUrlEncodedContent formData,HttpStatusCode expected )
        {
            var response = await _client.PostAsync($"/api/Product", formData);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(content);
            Assert.Equal(expected, response.StatusCode);
            Assert.NotNull(product);
        }

        [Theory]
        [InlineData(1008, SampleData.ProductDeleteMessage)]
        [Trait("Category", "IntegrationTest")]
        public async Task Delete_ReturnDeleteMessage(int productId, string expectedMessage)
        {
            var response = await _client.DeleteAsync($"/api/Product/{productId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expectedMessage, content);

        }
    }
}
