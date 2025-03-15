// Project: KitCore.InMemory.Repository

using KitCore.Domain.Dto;
using KitCore.Domain.Repository;
using KitCore.Utility;

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

public class InMemorySystemRepository : InMemoryRepository<SystemDto>
{
    protected override string GetEntityId(SystemDto entity) => entity.Id;
}

public class InMemoryPartRepository : InMemoryRepository<PartDto>
{
    protected override string GetEntityId(PartDto entity) => entity.Id;
}

public class InMemorySystemPartRepository : InMemoryRepository<SystemPartDto>
{
    protected override string GetEntityId(SystemPartDto entity) => entity.Id;
}

public class InMemoryPurchaseRepository : InMemoryRepository<PurchaseDto>
{
    protected override string GetEntityId(PurchaseDto entity) => entity.Id;
}

public class InMemoryUseCaseRepository : InMemoryRepository<UseCaseDto>
{
    protected override string GetEntityId(UseCaseDto entity) => entity.Id;
}

public class InMemoryUseCaseStepRepository : InMemoryRepository<UseCaseStepDto>
{
    protected override string GetEntityId(UseCaseStepDto entity) => entity.Id;
}

public class InMemoryUseCaseStepAssignmentRepository : InMemoryRepository<UseCaseStepAssignmentDto>
{
    protected override string GetEntityId(UseCaseStepAssignmentDto entity) => entity.Id;
}

public class InMemorySystemAttributeRepository : InMemoryRepository<SystemAttributeDto>
{
    protected override string GetEntityId(SystemAttributeDto entity) => entity.Id;
}

public class InMemorySystemPartAttributeRepository : InMemoryRepository<SystemPartAttributeDto>
{
    protected override string GetEntityId(SystemPartAttributeDto entity) => entity.Id;
}

public class InMemoryAttributeTypeRepository : InMemoryRepository<AttributeTypeDto>
{
    protected override string GetEntityId(AttributeTypeDto entity) => entity.Name;
}

public class InMemoryAttributeValueRepository : InMemoryRepository<AttributeValueDto>
{
    protected override string GetEntityId(AttributeValueDto entity) => entity.Id;
}

public class InMemorySystemTypeRepository : InMemoryRepository<SystemTypeDto>
{
    protected override string GetEntityId(SystemTypeDto entity) => entity.Name;
}

public class InMemorySystemPartTypeRepository : InMemoryRepository<SystemPartTypeDto>
{
    protected override string GetEntityId(SystemPartTypeDto entity) => entity.Name;
}

public class InMemorySystemTypeAttributeTypeRepository : InMemoryRepository<SystemTypeAttributeTypeDto>
{
    protected override string GetEntityId(SystemTypeAttributeTypeDto entity) => entity.Id;
}

public class InMemorySystemPartTypeAttributeTypeRepository : InMemoryRepository<SystemPartTypeAttributeTypeDto>
{
    protected override string GetEntityId(SystemPartTypeAttributeTypeDto entity) => entity.Id;
}

// Set Table Repositories
public class InMemoryBrandSetRepository : InMemoryRepository<BrandSetDto>
{
    protected override string GetEntityId(BrandSetDto entity) => entity.Name;
}

public class InMemoryCurrencySetRepository : InMemoryRepository<CurrencySetDto>
{
    protected override string GetEntityId(CurrencySetDto entity) => entity.Currency;
}

public class InMemoryModelSetRepository : InMemoryRepository<ModelSetDto>
{
    protected override string GetEntityId(ModelSetDto entity) => entity.Name;
}

public class InMemoryDataTypeSetRepository : InMemoryRepository<DataTypeSetDto>
{
    protected override string GetEntityId(DataTypeSetDto entity) => entity.DataType;
}

public class InMemoryUnitSetRepository : InMemoryRepository<UnitSetDto>
{
    protected override string GetEntityId(UnitSetDto entity) => entity.Name;
}
