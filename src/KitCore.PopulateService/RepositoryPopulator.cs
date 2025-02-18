using KitCore.Domain.Dto;
using KitCore.Domain.Repository;

namespace KitCore.PopulateService;

public sealed class RepositoryPopulator<T>(
    IRepository<T> repository, Func<KitCoreDataDto, IEnumerable<T>> FetchFunc) : IRepositoryPopulator
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
