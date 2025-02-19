using System;
using System.Reflection;

namespace KitCore.Utility;

public static class Validation
{
    public static IEnumerable<string> ValidateNotNullProperties<T>(this T record) where T : notnull
    {
        var errors = new List<string>();
        var type = record.GetType();
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in properties)
        {
            if (prop.PropertyType.IsValueType && Nullable.GetUnderlyingType(prop.PropertyType) == null)
            {
                continue; // Skip non-nullable value types
            }

            if (prop.PropertyType == typeof(string) && Attribute.IsDefined(prop, typeof(System.Runtime.CompilerServices.NullableAttribute)))
            {
                continue; // Skip explicitly nullable reference types (string?)
            }

            var value = prop.GetValue(record);
            if (value is null && prop.PropertyType.IsClass)
            {
                errors.Add($"{type.Name}: Property '{prop.Name}' is null but should not be.");
            }
        }

        return errors;
    }

    public static void ThrowIfNotNullPropertiesNull<T>(this T record) where T : notnull
    {
        var errors = ValidateNotNullProperties(record);
        if (errors.Any())
        {
            var message = string.Join(Environment.NewLine, errors);
            throw new ArgumentNullException(message);
        }
    }
}
