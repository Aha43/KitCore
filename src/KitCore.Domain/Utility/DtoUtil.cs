using System.Text;
using KitCore.Domain.Dto;
using KitCore.Utility;

namespace KitCore.Domain.Utility;

public static class DtoUtil
{
    public static string ToDisplayList(this KitCoreDataDto data)
    {
        if (data is null) return string.Empty;

        var sb = new StringBuilder();

        sb.AppendLine("KitCoreDataDto:");
        if (data.Brands != null)
        {
            sb.AppendLine($"{nameof(data.Brands)}:");
            sb.AppendLine(data.Brands.ToDisplayList());
        }
        if (data.Currencies != null)
        {
            sb.AppendLine($"{nameof(data.Currencies)}:");
            sb.AppendLine(data.Currencies.ToDisplayList());
        }
        if (data.Models != null)
        {
            sb.AppendLine($"{nameof(data.Models)}:");
            sb.AppendLine(data.Models.ToDisplayList());
        }
        if (data.Parts != null)
        {
            sb.AppendLine($"{nameof(data.Parts)}:");
            sb.AppendLine(data.Parts.ToDisplayList());
        }
        if (data.Purchases != null)
        {
            sb.AppendLine($"{nameof(data.Purchases)}:");
            sb.AppendLine(data.Purchases.ToDisplayList());
        }
        if (data.SystemAttributes != null)
        {
            sb.AppendLine($"{nameof(data.SystemAttributes)}:");
            sb.AppendLine(data.SystemAttributes.ToDisplayList());
        }
        if (data.SystemPartAttributes != null)
        {
            sb.AppendLine($"{nameof(data.SystemPartAttributes)}:");
            sb.AppendLine(data.SystemPartAttributes.ToDisplayList());
        }
        if (data.SystemParts != null)
        {
            sb.AppendLine($"{nameof(data.SystemParts)}:");
            sb.AppendLine(data.SystemParts.ToDisplayList());
        }
        if (data.Systems != null)
        {
            sb.AppendLine($"{nameof(data.Systems)}:");
            sb.AppendLine(data.Systems.ToDisplayList());
        }
        
        return sb.ToString().TrimEnd();
    }
}
