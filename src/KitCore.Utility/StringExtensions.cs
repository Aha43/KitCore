using System.Reflection;
using System.Text;

namespace KitCore.Utility;

public static class StringExtensions
{
    public static string ToUserFriendlyString<T>(this T record, bool writeType = false) where T : notnull
    {
        if (record is null) return string.Empty;

        var sb = new StringBuilder();
        var type = record.GetType();
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        if (writeType) sb.AppendLine($"{type.Name}:");

        foreach (var prop in properties)
        {
            var value = prop.GetValue(record) ?? "N/A";
            sb.AppendLine($"  {prop.Name}: {value}");
        }

        return sb.ToString().TrimEnd();
    }

    public static string ToDisplayList<T>(this IEnumerable<T> records) where T : notnull
    {
        var sb = new StringBuilder();
        bool first = true;
        foreach (var record in records)
        {
            if (record is null) continue;
            if (!first) 
            {
                sb.AppendLine();
            }
            sb.AppendLine(record.ToUserFriendlyString());
            first = false;
        }
        return sb.ToString().TrimEnd();
    }

}
