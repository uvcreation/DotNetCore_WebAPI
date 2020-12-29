using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Business.Implementation;
using WebAPI.Business.Models;
using WebAPI.Repository.Core;
using WebAPI.Repository.Entities;
using Xunit;

namespace WebAPI.Business.Test
{
    public class ProductDomainTest
    {
        private readonly Mock<IProductRepository> _mockProductRepository = new Mock<IProductRepository>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [Fact]
        public async Task Should_GetProductById_When_InputIsValid()
        {
            //Arrange
            var expectedResult = 1;
            var product = new Product() { Id = 1, Name = "Product  1", Cost = 100 };

            _mockProductRepository
                .Setup(p => p.GetById(expectedResult))
                .Returns(Task.FromResult(product));

            _mockMapper
                .Setup(m => m.Map<List<ProductModel>, List<Product>>(It.IsAny<List<ProductModel>>()))
                 .Verifiable();

            //Act
            var productDomain = new ProductDomain(_mockProductRepository.Object, _mockMapper.Object);
            var actualResult = await productDomain.GetProductById(expectedResult);

            //Assert
            var model = Assert.IsType<Product>(actualResult);
            Assert.Equal(expectedResult, model.Id);
        }

        [Fact]
        public async Task Should_GetAllProducts_When_InputIsValid()
        {
            //Arrange
            var expectedResult = new List<Product>
            {
                new Product() { Id = 1, Name = "Product  1", Cost = 100 },
                new Product() { Id = 2, Name = "Product  2", Cost = 150 },
             };

            _mockProductRepository
                .Setup(p => p.GetAllProducts())
                .Returns(Task.FromResult<IEnumerable<Product>>(expectedResult));

            _mockMapper
                .Setup(m => m.Map<List<ProductModel>, List<Product>>(It.IsAny<List<ProductModel>>()))
                 .Verifiable();

            //Act
            var productDomain = new ProductDomain(_mockProductRepository.Object, _mockMapper.Object);
            var actualResult = await productDomain.GetAllProducts();

            //Assert
            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(actualResult);
            Assert.Equal(expectedResult.Count, model.Count());
        }
    }
}
