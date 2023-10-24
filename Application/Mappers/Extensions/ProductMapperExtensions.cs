using Application.Dtos;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Mappers.Extensions
{
    //TODO: Create a generic and dynamic mapper
    public static class ProductMapperExtensions
    {
        public static ProductRequest MapToRequest(this Product source)
        {
            return new ProductRequest()
            {
                Name = source.Name,
                Description = source.Description,
                Stock = source.Stock,
                Status = source.Status,
                Price = source.Price
            };
        }

        public static ProductResponse MapToResponse(this Product source)
        {
            return new ProductResponse()
            {
                Name = source.Name,
                Description = source.Description,
                Stock = source.Stock,
                Status = source.Status,
                Price = source.Price,
                FinalPrice = source.FinalPrice
            };
        }

        public static List<ProductResponse> MapToResponse(this List<Product> sources)
        {
            var products = new List<ProductResponse>();

            foreach (var source in sources)
            {
                products.Add(new ProductResponse()
                {
                    Name = source.Name,
                    Description = source.Description,
                    Stock = source.Stock,
                    Status = source.Status,
                    Price = source.Price,
                    FinalPrice = source.FinalPrice
                });
            }

            return products;
        }

        public static Product MapToEntity(this ProductRequest source)
        {
            return new Product()
            {
                Name = source.Name,
                Description = source.Description,
                Stock = source.Stock,
                Status = source.Status,
                Price = source.Price
            };
        }
    }
}
