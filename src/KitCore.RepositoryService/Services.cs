using KitCore.Domain.Dto;
using KitCore.Domain.Implementation;
using KitCore.Domain.Service;
using Microsoft.Extensions.DependencyInjection;

namespace KitCore.RepositoryService;

public static class Services
{
    public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
    {
        services.AddSingleton<IRepositoryService<SystemDto>, SystemRepositoryService>();
        services.AddSingleton<IRepositoryService<PartDto>, PartRepositoryService>();

        services.AddSingleton<IRepositoryService<SystemPartDto>, RepositoryService<SystemPartDto>>();
        services.AddSingleton<IRepositoryService<SystemPartTypeDto>, RepositoryService<SystemPartTypeDto>>();
        services.AddSingleton<IRepositoryService<UnitSetDto>, RepositoryService<UnitSetDto>>();
        services.AddSingleton<IRepositoryService<ModelSetDto>, RepositoryService<ModelSetDto>>();
        services.AddSingleton<IRepositoryService<BrandSetDto>, RepositoryService<BrandSetDto>>();
        services.AddSingleton<IRepositoryService<CurrencySetDto>, RepositoryService<CurrencySetDto>>();
        services.AddSingleton<IRepositoryService<PurchaseDto>, RepositoryService<PurchaseDto>>();
        services.AddSingleton<IRepositoryService<UseCaseDto>, RepositoryService<UseCaseDto>>();
        services.AddSingleton<IRepositoryService<UseCaseStepDto>, RepositoryService<UseCaseStepDto>>();
        services.AddSingleton<IRepositoryService<SystemAttributeDto>, RepositoryService<SystemAttributeDto>>();
        return services;
    }
}
