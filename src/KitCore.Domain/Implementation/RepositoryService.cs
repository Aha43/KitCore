using KitCore.Domain.Repository;
using KitCore.Domain.Service;

namespace KitCore.Domain.Implementation;

public class RepositoryService<T>(IRepository<T> repository) : IRepositoryService<T> where T : class
{
    public virtual async Task CreateAsync(T entity) => await repository.CreateAsync(entity);
    public virtual async Task DeleteAsync(string id) => await repository.DeleteAsync(id);
    public virtual async Task<IEnumerable<T>> GetAllAsync() => await repository.GetAllAsync();
    public virtual async Task<T?> GetByIdAsync(string id) => await repository.GetByIdAsync(id);
    public virtual async Task UpdateAsync(T entity) => await repository.UpdateAsync(entity);
}