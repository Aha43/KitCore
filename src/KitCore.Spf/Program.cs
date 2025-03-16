// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using SimplePromptFramework;

using KitCore.Domain.Service.Json;
using KitCore.InMemory.Repository;
using KitCore.PopulateService;
using KitCore.Domain.Repository;
using KitCore.JsonService;
using KitCore.Domain.Dto;
using KitCore.RepositoryService;
using KitCore.Domain.Utility;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddKitCoreInMemoryRepositories();
        serviceCollection.AddPopulationServices();
        serviceCollection.AddRepositoryServices();
        serviceCollection.AddKitCoreJsonServices();

        var spf = new Spf(args, options =>
        {
            options.BaseNamespace = "KitCore.Spf.SpfHandlers";
            options.Services = serviceCollection;
        });

        await ImportJsonDataAsync(spf.ServiceProvider, args);

        await spf.StartAsync();
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
}