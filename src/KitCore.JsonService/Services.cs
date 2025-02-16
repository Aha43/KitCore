using KitCore.Domain.Service.Json;
using Microsoft.Extensions.DependencyInjection;

namespace KitCore.JsonService;

public static class Services
{
    public static IServiceCollection AddKitCoreJsonServices(this IServiceCollection services)
    {
        services.AddSingleton<IJsonImportService, JsonImportService>();
        return services;
    }
}
