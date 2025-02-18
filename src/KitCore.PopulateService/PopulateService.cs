using KitCore.Domain.Dto;
using KitCore.Domain.Repository;
using KitCore.Domain.Service;

namespace KitCore.PopulateService;

public class PopulateService(
    IRepository<UnitSetDto> unitsRepository,
    IRepository<BrandSetDto> brandRepository) : IPopulateService
{
    private readonly List<IRepositoryPopulator> _repositoryPopulators =
    [
        new RepositoryPopulator<UnitSetDto>(unitsRepository, e => e.Units),
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
