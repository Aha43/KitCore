namespace KitCore.Domain.Service.yaml;

public interface IYamlImportService
{
    Task ImportFromDirectoryAsync(string directoryPath);
}
