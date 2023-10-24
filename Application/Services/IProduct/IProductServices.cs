using Application.Dtos;
using Infrastructure.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IProducts
{
    public interface IProductServices
    {
        public Task<List<ProductResponse>> GetProducts();
        public Task<ProductResponse?> GetProduct(Guid id);
        public Task AddProduct(ProductRequest productDTO);
        public Task UpdateProduct(ProductRequest productDTO);
    }
}
