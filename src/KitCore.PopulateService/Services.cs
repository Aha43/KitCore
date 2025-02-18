using KitCore.Domain.Service;
using Microsoft.Extensions.DependencyInjection;

namespace KitCore.PopulateService;

public static class Services
{
    public static IServiceCollection AddPopulationServices(this IServiceCollection services)
    {
        return services.AddScoped<IPopulateService, PopulateService>();
    }
}
