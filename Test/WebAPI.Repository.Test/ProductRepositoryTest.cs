using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Repository.Core;
using WebAPI.Repository.Entities;
using WebAPI.Repository.Implementation;
using Xunit;

namespace WebAPI.Repository.Test
{
    public class ProductRepositoryTest
    {
        private readonly Mock<IDapperRepositoryBase> _mockDapperRepositoryBase = new Mock<IDapperRepositoryBase>();
        private readonly Mock<ICommandText> _mockCommandText = new Mock<ICommandText>();

        [Fact]
        public async Task Should_GetProductById_When_InputIsValid()
        {
            //Arrange
            var expectedResult = 1;
            var products = new List<Product>
            {
                new Product() { Id = 1, Name = "Product  1", Cost = 100 },
                new Product() { Id = 2, Name = "Product  2", Cost = 150 },
             };

            _mockDapperRepositoryBase
                .Setup(p => p.ExecuteQueryAsync<Product>(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult<IEnumerable<Product>>(products));

            _mockCommandText
                .Setup(c => c.GetProductById)
                 .Verifiable();

            //Act
            var productRepository = new ProductRepository(_mockDapperRepositoryBase.Object, _mockCommandText.Object);
            var actualResult = await productRepository.GetById(expectedResult);

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

            _mockDapperRepositoryBase
                .Setup(p => p.ExecuteQueryAsync<Product>(It.IsAny<string>()))
                .Returns(Task.FromResult<IEnumerable<Product>>(expectedResult));

            _mockCommandText
                .Setup(c => c.GetProducts)
                 .Verifiable();

            //Act
            var productRepository = new ProductRepository(_mockDapperRepositoryBase.Object, _mockCommandText.Object);
            var actualResult = await productRepository.GetAllProducts();

            //Assert
            var model = Assert.IsAssignableFrom<IEnumerable<Product>>(actualResult);
            Assert.Equal(expectedResult.Count, model.Count());
        }
    }
}
