using KitCore.Domain.Dto;
using KitCore.Domain.Service;

namespace KitCore.PopulateService;

public class PopulateService(
    IRepositoryService<SystemDto> systemRepository,
    IRepositoryService<PartDto> partRepository,
    IRepositoryService<SystemPartDto> systemPartRepository,
    IRepositoryService<SystemPartTypeDto> systemPartTypeRepository,
    IRepositoryService<UnitSetDto> unitsRepository,
    IRepositoryService<ModelSetDto> modelsRepository,
    IRepositoryService<BrandSetDto> brandRepository) : IPopulateService
{
    private readonly List<IRepositoryPopulator> _repositoryPopulators =
    [
        new RepositoryPopulator<SystemDto>(systemRepository, e => e.Systems),
        new RepositoryPopulator<PartDto>(partRepository, e => e.Parts),
        new RepositoryPopulator<SystemPartDto>(systemPartRepository, e => e.SystemParts),
        new RepositoryPopulator<SystemPartTypeDto>(systemPartTypeRepository, e => e.SystemPartTypes),
        new RepositoryPopulator<UnitSetDto>(unitsRepository, e => e.Units),
        new RepositoryPopulator<ModelSetDto>(modelsRepository, e => e.Models),
        new RepositoryPopulator<BrandSetDto>(brandRepository, e => e.Brands)
    ];

    public async Task PopulateAsync(KitCoreDataDto kitCoreDto)
    {
        foreach (var repositoryPopulator in _repositoryPopulators)
        {
            await repositoryPopulator.PopulateAsync(kitCoreDto);
        }
    }

}
