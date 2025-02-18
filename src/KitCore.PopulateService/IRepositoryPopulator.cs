using KitCore.Domain.Dto;

namespace KitCore.PopulateService;

public interface IRepositoryPopulator
{
    Task PopulateAsync(KitCoreDataDto kitCoreDto);
}
