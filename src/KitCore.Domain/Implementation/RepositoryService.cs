using System;
using KitCore.Domain.Repository;
using KitCore.Domain.Service;

namespace KitCore.Domain.Implementation;

public class RepositoryService<T>(IRepository<T> repository) : IRepositoryService<T> where T : class
{
    public async Task CreateAsync(T entity) => await repository.CreateAsync(entity);
    public async Task DeleteAsync(string id) => await repository.DeleteAsync(id);
    public async Task<IEnumerable<T>> GetAllAsync() => await repository.GetAllAsync();
    public async Task<T?> GetByIdAsync(string id) => await repository.GetByIdAsync(id);
    public async Task UpdateAsync(T entity) => await repository.UpdateAsync(entity);
}