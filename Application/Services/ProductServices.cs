using Application.Dtos;
using Application.Mappers.Extensions;
using Application.Services.IProducts;
using Domain.Entities;
using Infrastructure.DataAccess.Repositories;
using Infrastructure.ExternalServices.IExtenalServices;

namespace Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ProductRepository _productRepository;
        private readonly IDiscountService _discountService;

        public ProductServices(
            ProductRepository productRepository,
            IDiscountService discountService)
        {
            _productRepository = productRepository;
            _discountService = discountService;
        }

        public async Task<List<ProductResponse>> GetProducts()
        {
            var products = await _productRepository.GetAllAsync();
            var productsDto = products.MapToResponse();

            return productsDto;
        }
        public async Task<ProductResponse?> GetProduct(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product is null)
            {
                return new ProductResponse();
            }

            product.Discount = await _discountService.GetDiscountPercentageAsync(id);

            var productDto = product.MapToResponse(Discount: product.Discount);

            return productDto;
        }

        public async Task AddProduct(ProductRequest productDTO)
        {
            var product = productDTO.MapToEntity();

            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProduct(Guid id, ProductRequest productDTO)
        {
            var productFromDb = await _productRepository.GetByIdAsync(id);
            var product = productDTO.MapToEntity(response: productFromDb);

            await _productRepository.UpdateAsync(product);
        }

    }
}