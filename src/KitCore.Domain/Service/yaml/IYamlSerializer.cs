namespace KitCore.Domain.Service.yaml;

public interface IYamlSerializer
{
    Task ImportFromDirectoryAsync(string directoryPath);
}
