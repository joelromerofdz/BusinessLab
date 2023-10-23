﻿namespace Domain.Repositories
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<List<T>> GetAll();
        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
    }
}
