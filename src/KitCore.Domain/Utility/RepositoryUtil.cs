using System.Text;
using KitCore.Domain.Repository;
using KitCore.Utility;

namespace KitCore.Domain.Utility;

public static class RepositoryUtil
{
    public static async Task<string> ToDisplayListAsync<T>(this IRepository<T> repository) where T : class
    {
        var sb = new StringBuilder();
        var records = await repository.GetAllAsync();
        bool first = true;
        foreach (var record in records)
        {
            if (record is null) continue;
            if (!first) sb.AppendLine();
            sb.AppendLine(record.ToUserFriendlyString());
            first = false;
        }
        return sb.ToString().TrimEnd();
    }

    public static async Task DisplayListToConsoleAsync<T>(this IRepository<T> repository, bool writeRepositoryName = false) where T : class
    {
        var records = await repository.ToDisplayListAsync();
        if (writeRepositoryName) Console.WriteLine(repository.GetType().Name);
        Console.WriteLine(records);
    }

}
