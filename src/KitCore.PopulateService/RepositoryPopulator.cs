using KitCore.Domain.Dto;
using KitCore.Domain.Service;

namespace KitCore.PopulateService;

public sealed class RepositoryPopulator<T>(
    IRepositoryService<T> repository, Func<KitCoreDataDto, IEnumerable<T>> FetchFunc) : IRepositoryPopulator where T : class   
{
    public async Task PopulateAsync(KitCoreDataDto kitCoreDto)
    {
        var items = FetchFunc(kitCoreDto);
        foreach (var item in items)
        {
            await repository.CreateAsync(item);
        }
    }
}
