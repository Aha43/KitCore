using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace KitCore.YamlService;

public static class YamlSerializer
{
    public static async Task<T> DeserializeYamlAsync<T>(string filePath)
    {
        var serializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        var yamlText = await File.ReadAllTextAsync(filePath);
        var deserialized = serializer.Deserialize<T>(yamlText);
        return deserialized;
    }
   
}
