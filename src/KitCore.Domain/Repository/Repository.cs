using KitCore.Domain.Dto;

namespace KitCore.Domain.Repository;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(string id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(string id);
}

public interface ISystemRepository : IRepository<SystemDto> { }
public interface ISystemPartRepository : IRepository<SystemPartDto> { }
public interface IPurchaseRepository : IRepository<PurchaseDto> { }
public interface IUseCaseRepository : IRepository<UseCaseDto> { }
public interface IUseCaseStepRepository : IRepository<UseCaseStepDto> { }
public interface IUseCaseStepAssignmentRepository : IRepository<UseCaseStepAssignmentDto> { }
public interface ISystemAttributeRepository : IRepository<SystemAttributeDto> { }
public interface ISystemPartAttributeRepository : IRepository<SystemPartAttributeDto> { }
public interface IAttributeTypeRepository : IRepository<AttributeTypeDto> { }
public interface IAttributeValueRepository : IRepository<AttributeValueDto> { }
public interface ISystemTypeRepository : IRepository<SystemTypeDto> { }
public interface ISystemPartTypeRepository : IRepository<SystemPartTypeDto> { }
public interface ISystemTypeAttributeTypeRepository : IRepository<SystemTypeAttributeTypeDto> { }
public interface ISystemPartTypeAttributeTypeRepository : IRepository<SystemPartTypeAttributeTypeDto> { }

// Repositories for Set Tables
public interface IBrandSetRepository : IRepository<BrandSetDto> { }
public interface ICurrencySetRepository : IRepository<CurrencySetDto> { }
public interface IModelSetRepository : IRepository<ModelSetDto> { }
public interface IDataTypeSetRepository : IRepository<DataTypeSetDto> { }
public interface IUnitSetRepository : IRepository<UnitSetDto> { }

