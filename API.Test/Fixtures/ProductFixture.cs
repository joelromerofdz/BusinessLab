using Application.Dtos;
using Domain.Entities;

namespace API.Test.Fixtures
{
    internal static class ProductFixture
    {
        internal static Product ProductMock(Guid id)
        {
            return new Product()
            {
                Id = id,
                Name = "Item one",
                Description = "It is a test.",
                Price = 207,
                Discount = 0,
                Status = true,
                Stock = 107
            };
        }

        internal static ProductResponse ProductResponseMock()
        {
            return new ProductResponse()
            {
                Name = "Item one",
                Description = "It is a test.",
                Price = 207,
                Discount = 0,
                Status = true,
                Stock = 107
            };
        }
    }
}
