using KitCore.Domain.Dto;

namespace KitCore.Domain.Service;

public interface IPopulateService
{
    Task PopulateAsync(KitCoreDataDto kitCoreDto);
}
