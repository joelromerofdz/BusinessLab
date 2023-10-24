using Application.Dtos;
using Application.Mappers.Extensions;
using Application.Services.IProducts;
using Domain.Entities;
using Infrastructure.DataAccess.Repositories;

namespace Application.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ProductRepository _productRepository;

        public ProductServices(ProductRepository productRepository)
        {
            _productRepository = productRepository;
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

            var productDto = product.MapToResponse();

            return productDto;
        }

        public async Task AddProduct(ProductRequest productDTO)
        {
            var product = productDTO.MapToEntity();

            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProduct(ProductRequest productDTO)
        {
            var product = productDTO.MapToEntity();

            await _productRepository.UpdateAsync(product);
        }

    }
}