using Microsoft.AspNetCore.Mvc;
using Moq;
using StockManagementEntities.Models;
using System;
using System.Collections.Generic;
using ToysAndGamesApi.Controllers;
using ToysAndGamesBusiness;
using ToysAndGamesEntities;
using Xunit;

namespace ToysAndGamesTesting
{
    public class ProductUnitTest
    {
        private readonly Mock<IProductBusiness> _proB;
        private readonly ProductController _controller;
        List<Product> _expectedProducts = new List<Product>();
        public ProductUnitTest()
        {
            _proB = new Mock<IProductBusiness>();
            _controller = new ProductController(_proB.Object);

            _expectedProducts.Add(new Product { Id = 1, Name = "Spiderman", Description = "", AgeRestriction = 5, Company = "Marvel", Price = 200 });
            _expectedProducts.Add(new Product { Id = 2, Name = "Thor", Description = "", AgeRestriction = 5, Company = "Marvel", Price = 150 });
            _expectedProducts.Add(new Product { Id = 3, Name = "Hulk", Description = "", AgeRestriction = 5, Company = "Marvel", Price = 500 });
            _expectedProducts.Add(new Product { Id = 4, Name = "Superman", Description = "", AgeRestriction = 5, Company = "DC", Price = 1000 });
        }

        [Fact]
        public void Get_ReturnAllProducts()
        {
            _proB.Setup(p => p.Get()).Returns(_expectedProducts);

            ProductController _controller = new ProductController(_proB.Object);
            var actualProducts = _controller.Get();

            Assert.Equal(_expectedProducts, actualProducts.Value);
        }

        [Fact]
        public void GetByIdProduct_ReturnProductNotFound()
        {
            string messageEx = "Product Not Found";
            int productId = 1;
            _proB.Setup(p => p.GetById(It.IsAny<int>())).Throws(new Exception(messageEx));

            ProductController _controller = new ProductController(_proB.Object);
            var actualProducts = _controller.Get(productId);

            Assert.IsType<BadRequestObjectResult>(actualProducts.Result);
            Assert.Equal(messageEx, ((BadRequestObjectResult?)actualProducts.Result)?.Value);
        }

        [Fact]
        public void GetByIdProduct_ReturnProductFound()
        {
            int productId = 1;
            Product expectedProduct = new Product { Id = 1, Name = "Spiderman", Description = "", AgeRestriction = 5, Company = "Marvel", Price = 200 };
            _proB.Setup(p => p.GetById(It.IsAny<int>())).Returns(expectedProduct);

            ProductController _controller = new ProductController(_proB.Object);
            var actualProduct = _controller.Get(productId);
            Product? product = (Product?)actualProduct.Value;

            Assert.Equal(expectedProduct.Id, product?.Id);
        }

        [Fact]
        public void Post_CreateReturnCreatedProduct()
        {
            Product productToCreate = new Product { Id = 1, Name = "Spiderman", Description = "", AgeRestriction = 5, Company = "Marvel", Price = 200 };
            _proB.Setup(p => p.CreateOrUpdate(productToCreate)).Returns(productToCreate);

            ProductController _controller = new ProductController(_proB.Object);
            var actualProduct = _controller.PostOrUpdate(productToCreate);

            Assert.IsType<CreatedAtActionResult>(actualProduct.Result);
        }

        [Fact]
        public void Delete_ReturnMessageDelete()
        {
            string message = "The product has been deleted succesfully";
            int productId = 1;
            _proB.Setup(p => p.Delete(productId));

            ProductController _controller = new ProductController(_proB.Object);
            var actualProducts = _controller.Delete(productId);
            OkObjectResult? actionResult = (OkObjectResult?)actualProducts.Result;
            
            Assert.Equal(message, actionResult?.Value);
        }

    }
}