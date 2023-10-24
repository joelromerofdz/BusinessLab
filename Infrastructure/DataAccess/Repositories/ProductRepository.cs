using Domain.Entities;
using Infrastructure.DataAccess.Repositories.Base;

namespace Infrastructure.DataAccess.Repositories
{
    public class ProductRepository : BaseRepository<Product>
    {
        public ProductRepository(BusinessLabDbContext context) : base(context)
        {
        }
    }
}
