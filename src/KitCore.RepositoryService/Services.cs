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
        services.AddSingleton<IRepositoryService<PartDto>, RepositoryService<PartDto>>();
        services.AddSingleton<IRepositoryService<SystemPartDto>, RepositoryService<SystemPartDto>>();
        services.AddSingleton<IRepositoryService<UnitSetDto>, RepositoryService<UnitSetDto>>();
        services.AddSingleton<IRepositoryService<ModelSetDto>, RepositoryService<ModelSetDto>>();
        services.AddSingleton<IRepositoryService<BrandSetDto>, RepositoryService<BrandSetDto>>();
        return services;
    }
}
