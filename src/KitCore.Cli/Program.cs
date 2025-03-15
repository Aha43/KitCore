using KitCore.Domain.Service.Json;
using KitCore.InMemory.Repository;
using Microsoft.Extensions.DependencyInjection;
using KitCore.PopulateService;
using KitCore.Domain.Repository;
using KitCore.JsonService;
using KitCore.Domain.Dto;
using KitCore.RepositoryService;
using KitCore.Domain.Utility;

var serviceCollection = new ServiceCollection();
serviceCollection.AddKitCoreInMemoryRepositories();
serviceCollection.AddPopulationServices();
serviceCollection.AddRepositoryServices();
serviceCollection.AddKitCoreJsonServices();
var serviceProvider = serviceCollection.BuildServiceProvider();

if (args.Length == 0)
{
    Console.WriteLine("Usage: kitcore-cli <command> [options]");
    return;
}

var command = args[0];

try
{
    switch (command)
    {
        case "import":
            await ImportJsonDataAsync(serviceProvider, args);
            break;

        case "list-units":
            await ImportJsonDataAsync(serviceProvider, args);
            await ListAsync<UnitSetDto>(serviceProvider);
            break;

        case "list-brands":
            await ImportJsonDataAsync(serviceProvider, args);
            await ListAsync<BrandSetDto>(serviceProvider);
            break;

        case "list-systems":
            await ImportJsonDataAsync(serviceProvider, args);
            await ListAsync<SystemDto>(serviceProvider);
            break;

        default:
            Console.WriteLine($"Unknown command: {command}");
            break;
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex}");
}

static async Task ListAsync<T>(IServiceProvider serviceProvider) where T : class
{
    var repository = serviceProvider.GetRequiredService<IRepository<T>>();
    await RepositoryUtil.DisplayListToConsoleAsync(repository);
}

static async Task ImportJsonDataAsync(IServiceProvider serviceProvider, string[] args)
{
    if (args.Length < 2)
    {
        Console.WriteLine("Usage: kitcore-cli import <directory>");
        return;
    }

    var directoryPath = args[1];
    var jsonImportService = serviceProvider.GetRequiredService<IJsonImportService>();
    await jsonImportService.ImportFromDirectoryAsync(directoryPath);
}
