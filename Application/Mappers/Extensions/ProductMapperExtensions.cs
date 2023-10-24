using Application.Dtos;
using Domain.Entities;
using System;
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

        public static ProductResponse MapToResponse(this Product source, int Discount = 0)
        {
            return new ProductResponse()
            {
                Name = source.Name,
                Description = source.Description,
                Stock = source.Stock,
                Status = source.Status,
                StatusName = source.Status.StatusDictionary(),
                Price = source.Price,
                FinalPrice = source.FinalPrice,
                Discount = Discount
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

        public static Product MapToEntity(this ProductRequest source, Product? response = null)
        {
            if (response is null) 
            {
                var productAdd = new Product()
                {
                    Name = source.Name,
                    Description = source.Description,
                    Stock = source.Stock,
                    Status = source.Status,
                    Price = source.Price
                };

                return productAdd;
            }

            var productUpdate = (Product)response;
            productUpdate.Name = source.Name;
            productUpdate.Description = source.Description;
            productUpdate.Stock = source.Stock;
            productUpdate.Status = source.Status;
            productUpdate.Price = source.Price;
            productUpdate.LastModifiedDate = DateTime.Now;

            return productUpdate;
        }

        public static string StatusDictionary(this bool key)
        {
            var status = new Dictionary<bool, string>()
            {
                [true] = "Active",
                [false] = "Inactive"
            };

            return status.FirstOrDefault(s => s.Key == key).Value;
        }
    }
}
