using KitCore.Domain.Service.Json;
using KitCore.InMemory.Repository;
using Microsoft.Extensions.DependencyInjection;
using KitCore.PopulateService;
using KitCore.Domain.Repository;
using KitCore.Domain.Service;
using KitCore.JsonService;

var serviceCollection = new ServiceCollection();
serviceCollection.AddKitCoreInMemoryRepositories();
serviceCollection.AddPopulationServices();
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
            await ListUnitsAsync(serviceProvider);
            break;

        case "list-brands":
            await ImportJsonDataAsync(serviceProvider, args);
            await ListBrandsAsync(serviceProvider);
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

static async Task ListUnitsAsync(IServiceProvider serviceProvider)
{
    var unitSetRepo = serviceProvider.GetRequiredService<IUnitSetRepository>();
    var units = await unitSetRepo.GetAllAsync();
    Console.WriteLine("Defined Units:");
    foreach (var unit in units)
    {
        Console.WriteLine($"- {unit}");
    }
}

static async Task ListBrandsAsync(IServiceProvider serviceProvider)
{
    var brandSetRepo = serviceProvider.GetRequiredService<IBrandSetRepository>();
    var brands = await brandSetRepo.GetAllAsync();
    Console.WriteLine("Defined Brands:");
    foreach (var unit in brands)
    {
        Console.WriteLine($"- {unit.Name}");
    }
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

    var populateService = serviceProvider.GetRequiredService<IPopulateService>();
    
}
