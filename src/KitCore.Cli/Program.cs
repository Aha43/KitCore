// See https://aka.ms/new-console-template for more information
using KitCore.Domain.Repository;
using KitCore.Domain.Service.Json;
using KitCore.Domain.Service.yaml;
using KitCore.InMemory.Repository;
using KitCore.JsonService;
using KitCore.YamlService;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var serviceCollection = new ServiceCollection();
serviceCollection.AddKitCoreInMemoryRepositories();
serviceCollection.AddKitCoreYamlService();
serviceCollection.AddKitCoreJsonServices();
var serviceProvider = serviceCollection.BuildServiceProvider();
var jsonImportService = serviceProvider.GetRequiredService<IJsonImportService>();
var unitSetRepo = serviceProvider.GetRequiredService<IUnitSetRepository>();

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
            var units = await unitSetRepo.GetAllAsync();
            Console.WriteLine("Defined Units:");
            foreach (var unit in units)
            {
                Console.WriteLine($"- {unit.Name}");
            }
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
