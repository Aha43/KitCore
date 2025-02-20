using KitCore.Domain.Dto;
using KitCore.Domain.Implementation;
using KitCore.Domain.Repository;
using KitCore.Domain.Utility;
using KitCore.Utility;

namespace KitCore.RepositoryService;

public class SystemRepositoryService(
    IRepository<SystemDto> systemRepository,
    IRepository<BrandSetDto> brandSetRepository,
    IRepository<ModelSetDto> modelSetRepository)
    : RepositoryService<SystemDto>(systemRepository)
{
    public override async Task CreateAsync(SystemDto entity) 
    {
        Validation.ThrowIfNotNullPropertiesNull(entity);

        await modelSetRepository.ListToConsoleAsync();
       

        _ = await brandSetRepository.GetByIdAsync(entity.Brand) ?? throw new KeyNotFoundException($"Brand with ID {entity.Brand} not found.");
        //_ = await modelSetRepository.GetByIdAsync(entity.Model) ?? throw new KeyNotFoundException($"Model with ID {entity.Model} not found.");
        await base.CreateAsync(entity);
    }
}