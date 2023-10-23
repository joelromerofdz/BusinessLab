using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAnsyc(Guid id);
        List<T> GetAll();
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(Guid id);
    }
}
