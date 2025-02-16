using System.Text.Json;
using KitCore.Domain.Dto;
using KitCore.Domain.Repository;
using KitCore.Domain.Service.Json;

namespace KitCore.JsonService;
public class JsonImportService(IUnitSetRepository unitSetRepository) : IJsonImportService
{
    private readonly IUnitSetRepository _unitSetRepository = unitSetRepository;

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
        var data = JsonSerializer.Deserialize<KitCoreDataDto>(jsonText);

        if (data?.Units != null)
        {
            foreach (var unit in data.Units)
            {
                await _unitSetRepository.CreateAsync(unit);
            }
        }
    }
}
