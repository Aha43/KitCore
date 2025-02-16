using Microsoft.Extensions.DependencyInjection;
using KitCore.Domain.Repository;

namespace KitCore.InMemory.Repository;

public static class Services
{
    public static IServiceCollection AddKitCoreInMemoryRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ISystemRepository, InMemorySystemRepository>();
        services.AddSingleton<ISystemPartRepository, InMemorySystemPartRepository>();
        services.AddSingleton<IPurchaseRepository, InMemoryPurchaseRepository>();
        services.AddSingleton<IUseCaseRepository, InMemoryUseCaseRepository>();
        services.AddSingleton<IUseCaseStepRepository, InMemoryUseCaseStepRepository>();
        services.AddSingleton<IUseCaseStepAssignmentRepository, InMemoryUseCaseStepAssignmentRepository>();
        services.AddSingleton<ISystemAttributeRepository, InMemorySystemAttributeRepository>();
        services.AddSingleton<ISystemPartAttributeRepository, InMemorySystemPartAttributeRepository>();
        services.AddSingleton<IAttributeTypeRepository, InMemoryAttributeTypeRepository>();
        services.AddSingleton<IAttributeValueRepository, InMemoryAttributeValueRepository>();
        services.AddSingleton<ISystemTypeRepository, InMemorySystemTypeRepository>();
        services.AddSingleton<ISystemPartTypeRepository, InMemorySystemPartTypeRepository>();
        services.AddSingleton<ISystemTypeAttributeTypeRepository, InMemorySystemTypeAttributeTypeRepository>();
        services.AddSingleton<ISystemPartTypeAttributeTypeRepository, InMemorySystemPartTypeAttributeTypeRepository>();
        services.AddSingleton<IBrandSetRepository, InMemoryBrandSetRepository>();
        services.AddSingleton<ICurrencySetRepository, InMemoryCurrencySetRepository>();
        services.AddSingleton<IModelSetRepository, InMemoryModelSetRepository>();
        services.AddSingleton<IDataTypeSetRepository, InMemoryDataTypeSetRepository>();
        services.AddSingleton<IUnitSetRepository, InMemoryUnitSetRepository>();

        services.AddSingleton<IUnitSetRepository, InMemoryUnitSetRepository>();
        return services;
    }
}
