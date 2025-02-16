// See https://aka.ms/new-console-template for more information
using KitCore.Domain.Repository;
using KitCore.Domain.Service.yaml;
using KitCore.InMemory.Repository;
using KitCore.YamlService;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var serviceCollection = new ServiceCollection();
serviceCollection.AddKitCoreInMemoryRepositories();
serviceCollection.AddKitCoreYamlService();
var serviceProvider = serviceCollection.BuildServiceProvider();
var yamlImportService = serviceProvider.GetRequiredService<IYamlImportService>();
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
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: kitcore-cli import <directory>");
                return;
            }
            await yamlImportService.ImportFromDirectoryAsync(args[1]);
            Console.WriteLine("Import completed.");
            break;

        case "list-units":
            var units = await unitSetRepo.GetAllAsync();
            Console.WriteLine("Defined Units:");
            foreach (var unit in units)
            {
                Console.WriteLine($"- {unit.Unit}");
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

