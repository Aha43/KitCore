using KitCore.Domain.Service.yaml;
using Microsoft.Extensions.DependencyInjection;

namespace KitCore.YamlService;

public static class Services
{
    public static IServiceCollection AddKitCoreYamlService(this IServiceCollection services)
    {
        services.AddSingleton<IYamlImportService, YamlImportService>();
        return services;
    }
}
