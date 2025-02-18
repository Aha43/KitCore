using Microsoft.Extensions.DependencyInjection;
using KitCore.Domain.Repository;
using KitCore.Domain.Dto;

namespace KitCore.InMemory.Repository;

public static class Services
{
    public static IServiceCollection AddKitCoreInMemoryRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IRepository<SystemDto>, InMemorySystemRepository>();
        services.AddSingleton<IRepository<SystemPartDto>, InMemorySystemPartRepository>();
        services.AddSingleton<IRepository<PurchaseDto>, InMemoryPurchaseRepository>();
        services.AddSingleton<IRepository<UseCaseDto>, InMemoryUseCaseRepository>();
        services.AddSingleton<IRepository<UseCaseStepDto>, InMemoryUseCaseStepRepository>();
        services.AddSingleton<IRepository<UseCaseStepAssignmentDto>, InMemoryUseCaseStepAssignmentRepository>();
        services.AddSingleton<IRepository<SystemAttributeDto>, InMemorySystemAttributeRepository>();
        services.AddSingleton<IRepository<SystemPartAttributeDto>, InMemorySystemPartAttributeRepository>();
        services.AddSingleton<IRepository<AttributeTypeDto>, InMemoryAttributeTypeRepository>();
        services.AddSingleton<IRepository<AttributeValueDto>, InMemoryAttributeValueRepository>();
        services.AddSingleton<IRepository<SystemTypeDto>, InMemorySystemTypeRepository>();
        services.AddSingleton<IRepository<SystemPartTypeDto>, InMemorySystemPartTypeRepository>();
        services.AddSingleton<IRepository<SystemTypeAttributeTypeDto>, InMemorySystemTypeAttributeTypeRepository>();
        services.AddSingleton<IRepository<SystemPartTypeAttributeTypeDto>, InMemorySystemPartTypeAttributeTypeRepository>();
        services.AddSingleton<IRepository<BrandSetDto>, InMemoryBrandSetRepository>();
        services.AddSingleton<IRepository<CurrencySetDto>, InMemoryCurrencySetRepository>();
        services.AddSingleton<IRepository<ModelSetDto>, InMemoryModelSetRepository>();
        services.AddSingleton<IRepository<DataTypeSetDto>, InMemoryDataTypeSetRepository>();
        services.AddSingleton<IRepository<UnitSetDto>, InMemoryUnitSetRepository>();

        services.AddSingleton<IUnitSetRepository, InMemoryUnitSetRepository>();
        return services;
    }
}
