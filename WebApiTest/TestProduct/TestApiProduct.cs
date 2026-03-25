using ApiProduct.Application.Dto.Product.Request.Add;
using ApiProduct.Application.Services.Product;
using ApiProduct.Domain.Entities;
using ApiProduct.Domain.Repository;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;

namespace TestProduct
{
    public class TestApiProduct
    {
        [Fact]
        public async Task AddProduct()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<ProductService>>();
            var mockMapper = new Mock<IMapper>();
            var mockRepo = new Mock<IProductRepository>();

            var request = new AddProductRequestDto
            {
                Name = "Test",
                Price = 100
            };

            var product = new Product();

            mockMapper
                .Setup(m => m.Map<Product>(request))
                .Returns(product);

            var service = new ProductService(
                mockLogger.Object,
                mockMapper.Object,
                mockRepo.Object
            );

            var result = await service.AddProduct(request);

            Assert.NotNull(result);
            Assert.Equal("Test", result.Message);
        }

        [Fact]
        public async Task UpdateProduct()
        {
            var mockLogger = new Mock<ILogger<ProductService>>();
            var mockMapper = new Mock<IMapper>();
            var mockRepo = new Mock<IProductRepository>();

            var request = new AddProductRequestDto
            {
                Name = "Test",
                Price = 100
            };

            var product = new Product();

            mockMapper
                .Setup(m => m.Map<Product>(request))
                .Returns(product);

            var service = new ProductService(
                mockLogger.Object,
                mockMapper.Object,
                mockRepo.Object
            );

            var result = await service.AddProduct(request);

            Assert.NotNull(result);
            Assert.Equal("Test", result.Message);
        }

        [Fact]
        public async Task GetById()
        {
            var mockLogger = new Mock<ILogger<ProductService>>();
            var mockMapper = new Mock<IMapper>();
            var mockRepo = new Mock<IProductRepository>();

            var service = new ProductService(
                mockLogger.Object,
                mockMapper.Object,
                mockRepo.Object
            );

            var result = await service.GetById(2);

            Assert.NotNull(result);
            Assert.Equal("Test", result.Message);
        }
    }
}