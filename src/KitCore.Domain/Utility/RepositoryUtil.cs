using System.Text;
using KitCore.Domain.Repository;
using KitCore.Utility;

namespace KitCore.Domain.Utility;

public static class RepositoryUtil
{
    public static async Task<string> ToListAsync<T>(this IRepository<T> repository) where T : class
    {
        var sb = new StringBuilder();
        var records = await repository.GetAllAsync();
        foreach (var record in records)
        {
            if (record is null) continue;
            sb.AppendLine(record.ToUserFriendlyString());
        }
        return sb.ToString().TrimEnd();
    }

    public static async Task ListToConsoleAsync<T>(this IRepository<T> repository) where T : class
    {
        var records = await repository.ToListAsync();
        Console.WriteLine(repository.GetType().Name);
        Console.WriteLine(records);
    }

}
