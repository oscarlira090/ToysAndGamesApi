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
        public async Task GetByIdProduct_ReturnProductNotFound()
        {
            int productId = 0;
            var response = await _client.GetAsync($"/api/Product/{productId}");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
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

        [Fact]
        public async Task Post_CreateReturnCreatedProduct()
        {
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Name", "Spiderman"),
                new KeyValuePair<string, string>("Description", " "),
                new KeyValuePair<string, string>("AgeRestriction", "5"),
                new KeyValuePair<string, string>("Company", "Marvel"),
                new KeyValuePair<string, string>("Price", "200")
            });

            var response = await _client.PostAsync($"/api/Product", formContent);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(content);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(product);
        }

        [Fact]
        public async Task Delete_ReturnMessageDelete()
        {
            int productId = 1008;
            string message = "The product has been deleted succesfully";
            var response = await _client.DeleteAsync($"/api/Product/{productId}");
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(message, content);

        }
    }
}
