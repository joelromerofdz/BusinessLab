using API.Controllers;
using API.Test.Fixtures;
using Application.Dtos;
using Application.Services.IProducts;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace API.Test
{
    internal class ProductControllerTests
    {
        private readonly Mock<IProductServices> _productServices;
        private readonly Mock<IRepository<Product>> _BaseRepository;

        private ProductController _sut;

        public ProductControllerTests()
        {
            this._productServices = new Mock<IProductServices>();
            this._BaseRepository = new Mock<IRepository<Product>>();
        }

        [SetUp]
        public void Setup()
        {
            this._sut = new ProductController(this._productServices.Object);
        }

        [Test]
        public async Task Get_OnSuccess_ReturnOneProductById()
        {
            #region Arrage
            var id = Guid.NewGuid();

            this._BaseRepository
                .Setup(r => r.GetByIdAsync(id))
                .ReturnsAsync(ProductFixture.ProductMock(id));

            this._productServices
                .Setup(x => x.GetProduct(id))
                .ReturnsAsync(ProductFixture.ProductResponseMock());
            #endregion

            #region Act
            var result = await _sut.Get(id);
            OkObjectResult objectResult = (OkObjectResult)result;
            #endregion

            #region Assert
            objectResult.Value.Should().BeOfType<ProductResponse>();
            #endregion
        }

        [Test]
        public async Task Get_OnProductNoFound_Return404()
        {
            #region Arrage
            var id = Guid.NewGuid();

            this._BaseRepository
                .Setup(r => r.GetByIdAsync(id))
                .ReturnsAsync(() => null);

            this._productServices
                .Setup(x => x.GetProduct(id))
                .ReturnsAsync(() => null);
            #endregion

            #region Act
            var result = await _sut.Get(id);
            NotFoundObjectResult objectResult = (NotFoundObjectResult)result;
            #endregion

            #region Assert
            objectResult.Should().BeOfType<NotFoundObjectResult>();
            Assert.That(objectResult.Value, Is.EqualTo($"The product with ID = {id} not found."));
            #endregion
        }

        [Test]
        public async Task Post_OnSuccess_CreateProduct()
        {
            #region Arrage
            var product = new ProductRequest()
            {
                Name = "Item Test",
                Description = "It is a test.",
                Price = 123,
                Discount = 34,
                Status = true,
                Stock = 10
            };

            this._productServices
                .Setup(x => x.AddProduct(product));
            #endregion

            #region Act
            var result = await _sut.Post(product);
            OkObjectResult objectResult = (OkObjectResult)result;
            #endregion

            #region Assert
            objectResult.Value.Should().BeOfType<ProductRequest>();
            #endregion
        }

        [Test]
        public async Task Post_OnNoProductRequestSent_ReturnBadRequest()
        {
            #region Arrage
            ProductRequest product = null;

            this._productServices
                .Setup(x => x.AddProduct(product));
            #endregion

            #region Act
            var result = await _sut.Post(product);
            BadRequestObjectResult objectResult = (BadRequestObjectResult)result;
            #endregion

            #region Assert
            objectResult.Should().BeOfType<BadRequestObjectResult>();
            Assert.That(objectResult.Value, Is.EqualTo("Product values are empty."));
            #endregion
        }

        [Test]
        public async Task Put_OnSuccess_UpdateProduct()
        {
            #region Arrage
            var id = Guid.NewGuid();
            var product = new ProductRequest()
            {
                Name = "New iteam name"
            };

            this._productServices
                .Setup(x => x.GetProduct(id))
                .ReturnsAsync(ProductFixture.ProductResponseMock());

            this._productServices
                .Setup(x => x.UpdateProduct(product));
            #endregion

            #region Act
            var result = await _sut.Put(id, product);
            OkResult objectResult = (OkResult)result;
            #endregion

            #region Assert
            objectResult.StatusCode.Should().Be(200);
            #endregion
        }

        [Test]
        public async Task Put_OnIdProductIsSentEmpty_ReturnBadRequest()
        {
            #region Arrage
            Guid id = Guid.Empty;
            var product = new ProductRequest()
            {
                Name = "New iteam name"
            };

            this._productServices
                .Setup(x => x.GetProduct(id))
                .ReturnsAsync(() => null);

            this._productServices
                .Setup(x => x.UpdateProduct(product));
            #endregion

            #region Act
            var result = await _sut.Put(id, product);
            BadRequestObjectResult objectResult = (BadRequestObjectResult)result;
            #endregion

            #region Assert
            objectResult.Should().BeOfType<BadRequestObjectResult>();
            Assert.That(objectResult.Value, Is.EqualTo("Product values are empty."));
            #endregion
        }

        [Test]
        public async Task Put_OnProductRequestIsSentNull_ReturnBadRequest()
        {
            #region Arrage
            Guid id = Guid.NewGuid();
            ProductRequest product = null;

            this._productServices
                .Setup(x => x.GetProduct(id))
                .ReturnsAsync(() => null);

            this._productServices
                .Setup(x => x.UpdateProduct(product));
            #endregion

            #region Act
            var result = await _sut.Put(id, product);
            BadRequestObjectResult objectResult = (BadRequestObjectResult)result;
            #endregion

            #region Assert
            objectResult.Should().BeOfType<BadRequestObjectResult>();
            Assert.That(objectResult.Value, Is.EqualTo("Product values are empty."));
            #endregion
        }

        [Test]
        public async Task Put_OnOnProductNoFound_Return404()
        {
            #region Arrage
            Guid id = Guid.NewGuid();
            var product = new ProductRequest()
            {
                Name = "New iteam name"
            };

            this._productServices
                .Setup(x => x.GetProduct(id))
                .ReturnsAsync(() => null);

            this._productServices
                .Setup(x => x.UpdateProduct(product));
            #endregion

            #region Act
            var result = await _sut.Put(id, product);
            NotFoundObjectResult objectResult = (NotFoundObjectResult)result;
            #endregion

            #region Assert
            objectResult.Should().BeOfType<NotFoundObjectResult>();
            Assert.That(objectResult.Value, Is.EqualTo("Product does not exist."));
            #endregion
        }
    }
}
