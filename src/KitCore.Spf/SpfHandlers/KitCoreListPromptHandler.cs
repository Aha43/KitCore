using KitCore.Domain.Repository;
using KitCore.Domain.Utility;
using KitCore.Utility;
using SimplePromptFramework;

namespace KitCore.Spf.SpfHandlers;

public abstract class KitCoreListPromptHandler<T>(IRepository<T> repository) : ISpfPromptHandler where T : class
{
    public async Task HandlePromptAsync(string[] path, string[] input, SpfState state)
    {
        if (input.Length > 0)
        {
            foreach (var name in input)
            {
                var e = await repository.GetByIdAsync(name);
                Console.WriteLine(e.ToUserFriendlyString());
            }
        }
        else
        {
            await RepositoryUtil.DisplayListToConsoleAsync(repository);
        }
    }
}
