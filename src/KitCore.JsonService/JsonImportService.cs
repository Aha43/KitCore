using System.Text.Json;
using KitCore.Domain.Dto;
using KitCore.Domain.Service;
using KitCore.Domain.Service.Json;
using KitCore.Domain.Utility;

namespace KitCore.JsonService;
public class JsonImportService(IPopulateService populateService) : IJsonImportService
{
    public async Task ImportFromDirectoryAsync(string directoryPath)
    {
        var jsonFiles = Directory.GetFiles(directoryPath, "*.json")
            .OrderBy(file => file)  // Ensure files are processed in order
            .ToList();

        foreach (var file in jsonFiles)
        {
            Console.WriteLine($"Processing: {file}");
            await ImportFileAsync(file);
        }
    }

    private async Task ImportFileAsync(string filePath)
    {
        var jsonText = await File.ReadAllTextAsync(filePath);
        var data = JsonSerializer.Deserialize<KitCoreDataDto>(jsonText) ?? throw new InvalidOperationException($"Failed to deserialize JSON from file: {filePath}");
        await populateService.PopulateAsync(data);
    }

}
