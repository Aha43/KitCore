namespace KitCore.Domain.Dto;

public class KitCoreDataDto
{
    public IEnumerable<BrandSetDto> BrandSets { get; set; } = [];
    public IEnumerable<ModelSetDto> ModelSets { get; set; } = [];
    public IEnumerable<CurrencySetDto> CurrencySets { get; set; } = [];
    public IEnumerable<SystemDto> Systems { get; set; } = [];
    public IEnumerable<SystemPartDto> SystemParts { get; set; } = [];
    public IEnumerable<PurchaseDto> Purchases { get; set; } = [];
    public IEnumerable<UseCaseDto> UseCases { get; set; } = [];
    public IEnumerable<UseCaseStepDto> UseCaseSteps { get; set; } = [];
    public IEnumerable<SystemAttributeDto> SystemAttributes { get; set; } = [];
    public IEnumerable<SystemPartAttributeDto> SystemPartAttributes { get; set; } = [];
}
