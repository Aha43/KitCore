using KitCore.Domain.Dto;
using KitCore.Domain.Implementation;
using KitCore.Domain.Repository;
using KitCore.Utility;

namespace KitCore.RepositoryService;

public class PartRepositoryService(
    IRepository<PartDto> systemRepository,
    IRepository<BrandSetDto> brandSetRepository,
    IRepository<SystemPartTypeDto> systemPartTypeRepository,
    IRepository<ModelSetDto> modelSetRepository)
    : RepositoryService<PartDto>(systemRepository)
{
    public override async Task CreateAsync(PartDto entity) 
    {
        Validation.ThrowIfNotNullPropertiesNull(entity);

        _ = await brandSetRepository.GetByIdAsync(entity.Brand) ?? throw new KeyNotFoundException($"Brand with ID {entity.Brand} not found.");
        _ = await systemPartTypeRepository.GetByIdAsync(entity.SystemPartTypeName) ?? throw new KeyNotFoundException($"SystemPartType with ID {entity.SystemPartTypeName} not found.");
        _ = await modelSetRepository.GetByIdAsync(entity.Model) ?? throw new KeyNotFoundException($"Model with ID {entity.Model} not found.");
        await base.CreateAsync(entity);
    }
}
