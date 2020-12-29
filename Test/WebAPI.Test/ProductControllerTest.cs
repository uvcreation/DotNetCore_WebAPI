using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Business.Core;
using WebAPI.Business.Models;
using WebAPI.Controllers;
using WebAPI.Repository.Entities;
using Xunit;

namespace WebAPI.Test
{
    public class ProductControllerTest
    {
        private readonly Mock<IProductDomain> _mockProductDomain = new Mock<IProductDomain>();
        
        [Fact]
        public async Task Should_GetProductById_When_InputIsValid()
        {
            //Arrange
            var expectedResult = StatusCodes.Status200OK;
            var productId = 1;
            var product = new Product() { Id = 1, Name = "Product  1", Cost = 100 };

            _mockProductDomain
                .Setup(p => p.GetProductById(productId))
                .Returns(Task.FromResult(product));

            //Act
            var productController = new ProductController(_mockProductDomain.Object);
            var result = await productController.GetById(productId);

            //Assert
            var actualResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResult, actualResult.StatusCode);
        }

        [Fact]
        public async Task Should_GetAllProducts_When_InputIsValid()
        {
            //Arrange
            var expectedResult = StatusCodes.Status200OK;
            var products = new List<Product>
            {
                new Product() { Id = 1, Name = "Product  1", Cost = 100 },
                new Product() { Id = 2, Name = "Product  2", Cost = 150 },
             };

            _mockProductDomain
                .Setup(p => p.GetAllProducts())
                .Returns(Task.FromResult<IEnumerable<Product>>(products));

            //Act
            var productController = new ProductController(_mockProductDomain.Object);
            var result = await productController.GellAll();

            //Assert
            var actualResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(expectedResult, actualResult.StatusCode);
        }

        [Fact]
        public async Task Should_AddProducts_When_InputIsValid()
        {
            //Arrange
            var expectedResult = StatusCodes.Status200OK;
            var productModels = new List<ProductModel>
            {
                new ProductModel() { Name = "Product  1", Cost = 100 },
                new ProductModel() { Name = "Product  2", Cost = 150 },
             };

            _mockProductDomain
                .Setup(p => p.AddProducts(It.IsAny<List<ProductModel>>()))
                .Verifiable();

            //Act
            var productController = new ProductController(_mockProductDomain.Object);
            var result = await productController.AddProducts(productModels);

            //Assert
            var actualResult = Assert.IsType<OkResult>(result);
            Assert.Equal(expectedResult, actualResult.StatusCode);
        }

        [Fact]
        public async Task AddProducts_Should_ThrowBadRequest_When_InputIsNotValid()
        {
            //Arrange
            var expectedResult = StatusCodes.Status400BadRequest;
            
            _mockProductDomain
                .Setup(p => p.AddProducts(It.IsAny<List<ProductModel>>()))
                .Verifiable();

            //Act
            var productController = new ProductController(_mockProductDomain.Object);
            productController.ModelState.AddModelError("Bad Request","Model should not be null!");

            var result = await productController.AddProducts(null);

            //Assert
            var actualResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedResult, actualResult.StatusCode);
        }

        [Fact]
        public async Task Should_UpdateProducts_When_InputIsValid()
        {
            //Arrange
            var expectedResult = StatusCodes.Status200OK;
            var products = new List<Product>
            {
                new Product() {Id = 1, Name = "Product  1", Cost = 100 },
                new Product() {Id = 2, Name = "Product  2", Cost = 150 },
             };

            _mockProductDomain
                .Setup(p => p.UpdateProducts(It.IsAny<List<Product>>()))
                .Verifiable();

            //Act
            var productController = new ProductController(_mockProductDomain.Object);
            var result = await productController.Updates(products);

            //Assert
            var actualResult = Assert.IsType<OkResult>(result);
            Assert.Equal(expectedResult, actualResult.StatusCode);
        }

        [Fact]
        public async Task UpdateProducts_Should_ThrowBadRequest_When_InputIsNotValid()
        {
            //Arrange
            var expectedResult = StatusCodes.Status400BadRequest;

            _mockProductDomain
                .Setup(p => p.UpdateProducts(It.IsAny<List<Product>>()))
                .Verifiable();

            //Act
            var productController = new ProductController(_mockProductDomain.Object);
            productController.ModelState.AddModelError("Bad Request", "Model should not be null!");

            var result = await productController.Updates(null);

            //Assert
            var actualResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedResult, actualResult.StatusCode);
        }
    }
}
