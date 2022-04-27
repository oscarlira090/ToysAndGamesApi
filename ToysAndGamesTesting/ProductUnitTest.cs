using Microsoft.AspNetCore.Mvc;
using Moq;
using StockManagementEntities.Models;
using System;
using System.Collections.Generic;
using ToysAndGamesApi.Controllers;
using ToysAndGamesServices.Contracts;
using Xunit;

namespace ToysAndGamesTesting
{
    public class ProductUnitTest
    {
        private readonly Mock<IProductService> _proB;
        private readonly ProductController _controller;
        

        public ProductUnitTest()
        {
            _proB = new Mock<IProductService>();
            _controller = new ProductController(_proB.Object);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public void Get_ReturnAllProducts()
        {
            _proB.Setup(p => p.Get()).Returns(SampleData.GetSampleProducts());

            ProductController _controller = new ProductController(_proB.Object);
            var actualProducts = _controller.Get();

            Assert.Equal(SampleData.GetSampleProducts().Count, ((List<Product>)actualProducts.Value).Count);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public void GetByIdProduct_ReturnProductNotFound()
        {
            _proB.Setup(p => p.GetById(It.IsAny<int>())).Throws(new Exception(SampleData.ProductNotFoundMessage));

            ProductController _controller = new ProductController(_proB.Object);
            var actualProducts = _controller.Get(1);

            Assert.IsType<BadRequestObjectResult>(actualProducts.Result);
            Assert.Equal(SampleData.ProductNotFoundMessage, ((BadRequestObjectResult?)actualProducts.Result)?.Value);
            _proB.Verify(x => x.GetById(It.IsAny<int>()),Times.Exactly(1));


        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public void GetByIdProduct_ReturnProductFound()
        {
            Product expectedProduct = SampleData.GetSampleProduct();
            _proB.Setup(p => p.GetById(It.IsAny<int>())).Returns(expectedProduct);

            ProductController _controller = new ProductController(_proB.Object);
            var actualProduct = _controller.Get(1);
            Product? product = (Product?)actualProduct.Value;

            Assert.Equal(expectedProduct.Id, product?.Id);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public void Post_CreateReturnCreatedProduct()
        {
            Product productToCreate = SampleData.GetSampleProduct();
            _proB.Setup(p => p.UpSert(productToCreate)).Returns(productToCreate);

            ProductController _controller = new ProductController(_proB.Object);
            var actualProduct = _controller.PostOrUpdate(productToCreate);

            Assert.IsType<CreatedAtActionResult>(actualProduct.Result);
        }

        [Fact]
        [Trait("Category", "UnitTest")]
        public void Delete_ReturnDeleteMessage()
        {
            _proB.Setup(p => p.Delete(It.IsAny<int>()));

            ProductController _controller = new ProductController(_proB.Object);
            var actualProducts = _controller.Delete(1);
            OkObjectResult? actionResult = (OkObjectResult?)actualProducts.Result;
            
            Assert.Equal(SampleData.ProductDeleteMessage, actionResult?.Value);
        }
    }
}