using KitCore.Domain.Dto;
using KitCore.Domain.Repository;
using KitCore.Domain.Service.yaml;

namespace KitCore.YamlService;

public class YamlImportService : IYamlImportService
{
    private readonly Dictionary<Type, object> _repositories;

    public YamlImportService(
        IBrandSetRepository brandSetRepo,
        IModelSetRepository modelSetRepo,
        ICurrencySetRepository currencySetRepo,
        ISystemRepository systemRepo,
        ISystemPartRepository systemPartRepo,
        IPurchaseRepository purchaseRepo,
        IUseCaseRepository useCaseRepo,
        IUseCaseStepRepository useCaseStepRepo,
        ISystemAttributeRepository systemAttributeRepo,
        ISystemPartAttributeRepository systemPartAttributeRepo,
        IUnitSetRepository unitSetRepo)
    {
        _repositories = new Dictionary<Type, object>
        {
            { typeof(IBrandSetRepository), brandSetRepo },
            { typeof(IModelSetRepository), modelSetRepo },
            { typeof(ICurrencySetRepository), currencySetRepo },
            { typeof(ISystemRepository), systemRepo },
            { typeof(ISystemPartRepository), systemPartRepo },
            { typeof(IPurchaseRepository), purchaseRepo },
            { typeof(IUseCaseRepository), useCaseRepo },
            { typeof(IUseCaseStepRepository), useCaseStepRepo },
            { typeof(ISystemAttributeRepository), systemAttributeRepo },
            { typeof(ISystemPartAttributeRepository), systemPartAttributeRepo },
            { typeof(IUnitSetRepository), unitSetRepo }
        };
    }

    public async Task ImportFromDirectoryAsync(string directoryPath)
    {
        var yamlFiles = Directory.GetFiles(directoryPath, "*.yaml")
            .OrderBy(file => file)  // Ensures 0000_* loads before 9999_*
            .ToList();

        foreach (var file in yamlFiles)
        {
            Console.WriteLine($"Processing: {file}");
            await ImportFileAsync(file);
        }
    }

    private async Task ImportFileAsync(string filePath)
    {
        var data = await YamlSerializer.DeserializeYamlAsync<KitCoreDataDto>(filePath);
        await ImportData(data);
    }

    private async Task ImportData(KitCoreDataDto data)
    {
        await ImportEntities(data.BrandSets, typeof(IBrandSetRepository));
        await ImportEntities(data.ModelSets, typeof(IModelSetRepository));
        await ImportEntities(data.CurrencySets, typeof(ICurrencySetRepository));

        await ImportEntities(data.Systems, typeof(ISystemRepository));
        await ImportEntities(data.SystemParts, typeof(ISystemPartRepository));
        await ImportEntities(data.Purchases, typeof(IPurchaseRepository));

        await ImportEntities(data.UseCases, typeof(IUseCaseRepository));
        await ImportEntities(data.UseCaseSteps, typeof(IUseCaseStepRepository));

        await ImportEntities(data.SystemAttributes, typeof(ISystemAttributeRepository));
        await ImportEntities(data.SystemPartAttributes, typeof(ISystemPartAttributeRepository));
    }

    private async Task ImportEntities<T>(IEnumerable<T> entities, Type repositoryType)
    {
        if (entities == null || !entities.Any()) return;

        if (_repositories.TryGetValue(repositoryType, out var repoObject) && repoObject is IRepository<T> repository)
        {
            foreach (var entity in entities)
            {
                await repository.CreateAsync(entity);
            }
        }
        else
        {
            Console.WriteLine($"Warning: No repository found for {typeof(T).Name}");
        }
    }

}
