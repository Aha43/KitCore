// Project: KitCore.InMemory.Repository

using KitCore.Domain.Dto;
using KitCore.Domain.Repository;

namespace KitCore.InMemory.Repository;

public abstract class InMemoryRepository<T> : IRepository<T> where T : class
{
    protected readonly Dictionary<string, T> _store = [];

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult(_store.Values.AsEnumerable());
    }

    public Task<T?> GetByIdAsync(string id)
    {
        _store.TryGetValue(id, out var entity);
        return Task.FromResult(entity);
    }

    public Task CreateAsync(T entity)
    {
        var id = GetEntityId(entity);
        if (_store.ContainsKey(id))
        {
            throw new InvalidOperationException($"Entity with ID {id} already exists.");
        }
        _store[id] = entity;
        return Task.CompletedTask;
    }

    public Task UpdateAsync(T entity)
    {
        var id = GetEntityId(entity);
        if (!_store.ContainsKey(id))
        {
            throw new KeyNotFoundException($"Entity with ID {id} not found.");
        }
        _store[id] = entity;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(string id)
    {
        if (!_store.Remove(id))
        {
            throw new KeyNotFoundException($"Entity with ID {id} not found.");
        }
        return Task.CompletedTask;
    }

    protected abstract string GetEntityId(T entity);
}

public class InMemorySystemRepository : InMemoryRepository<SystemDto>, ISystemRepository
{
    protected override string GetEntityId(SystemDto entity) => entity.Id;
}

public class InMemorySystemPartRepository : InMemoryRepository<SystemPartDto>, ISystemPartRepository
{
    protected override string GetEntityId(SystemPartDto entity) => entity.Id;
}

public class InMemoryPurchaseRepository : InMemoryRepository<PurchaseDto>, IPurchaseRepository
{
    protected override string GetEntityId(PurchaseDto entity) => entity.Id;
}

public class InMemoryUseCaseRepository : InMemoryRepository<UseCaseDto>, IUseCaseRepository
{
    protected override string GetEntityId(UseCaseDto entity) => entity.Id;
}

public class InMemoryUseCaseStepRepository : InMemoryRepository<UseCaseStepDto>, IUseCaseStepRepository
{
    protected override string GetEntityId(UseCaseStepDto entity) => entity.Id;
}

public class InMemoryUseCaseStepAssignmentRepository : InMemoryRepository<UseCaseStepAssignmentDto>, IUseCaseStepAssignmentRepository
{
    protected override string GetEntityId(UseCaseStepAssignmentDto entity) => entity.Id;
}

public class InMemorySystemAttributeRepository : InMemoryRepository<SystemAttributeDto>, ISystemAttributeRepository
{
    protected override string GetEntityId(SystemAttributeDto entity) => entity.Id;
}

public class InMemorySystemPartAttributeRepository : InMemoryRepository<SystemPartAttributeDto>, ISystemPartAttributeRepository
{
    protected override string GetEntityId(SystemPartAttributeDto entity) => entity.Id;
}

public class InMemoryAttributeTypeRepository : InMemoryRepository<AttributeTypeDto>, IAttributeTypeRepository
{
    protected override string GetEntityId(AttributeTypeDto entity) => entity.Name;
}

public class InMemoryAttributeValueRepository : InMemoryRepository<AttributeValueDto>, IAttributeValueRepository
{
    protected override string GetEntityId(AttributeValueDto entity) => entity.Id;
}

public class InMemorySystemTypeRepository : InMemoryRepository<SystemTypeDto>, ISystemTypeRepository
{
    protected override string GetEntityId(SystemTypeDto entity) => entity.Name;
}

public class InMemorySystemPartTypeRepository : InMemoryRepository<SystemPartTypeDto>, ISystemPartTypeRepository
{
    protected override string GetEntityId(SystemPartTypeDto entity) => entity.Name;
}

public class InMemorySystemTypeAttributeTypeRepository : InMemoryRepository<SystemTypeAttributeTypeDto>, ISystemTypeAttributeTypeRepository
{
    protected override string GetEntityId(SystemTypeAttributeTypeDto entity) => entity.Id;
}

public class InMemorySystemPartTypeAttributeTypeRepository : InMemoryRepository<SystemPartTypeAttributeTypeDto>, ISystemPartTypeAttributeTypeRepository
{
    protected override string GetEntityId(SystemPartTypeAttributeTypeDto entity) => entity.Id;
}

// Set Table Repositories
public class InMemoryBrandSetRepository : InMemoryRepository<BrandSetDto>, IBrandSetRepository
{
    protected override string GetEntityId(BrandSetDto entity) => entity.Brand;
}

public class InMemoryCurrencySetRepository : InMemoryRepository<CurrencySetDto>, ICurrencySetRepository
{
    protected override string GetEntityId(CurrencySetDto entity) => entity.Currency;
}

public class InMemoryModelSetRepository : InMemoryRepository<ModelSetDto>, IModelSetRepository
{
    protected override string GetEntityId(ModelSetDto entity) => entity.Model;
}

public class InMemoryDataTypeSetRepository : InMemoryRepository<DataTypeSetDto>, IDataTypeSetRepository
{
    protected override string GetEntityId(DataTypeSetDto entity) => entity.DataType;
}

public class InMemoryUnitSetRepository : InMemoryRepository<UnitSetDto>, IUnitSetRepository
{
    protected override string GetEntityId(UnitSetDto entity) => entity.Unit;
}
