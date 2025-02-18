namespace KitCore.Domain.Dto;

public class KitCoreDataDto
{
    public IEnumerable<BrandSetDto> Brands { get; set; } = [];
    public IEnumerable<ModelSetDto> Models { get; set; } = [];
    public IEnumerable<CurrencySetDto> Currencies { get; set; } = [];
    public IEnumerable<SystemDto> Systems { get; set; } = [];
    public IEnumerable<PartDto> Parts { get; set; } = [];
    public IEnumerable<SystemPartDto> SystemParts { get; set; } = [];
    public IEnumerable<PurchaseDto> Purchases { get; set; } = [];
    public IEnumerable<UseCaseDto> UseCases { get; set; } = [];
    public IEnumerable<UseCaseStepDto> UseCaseSteps { get; set; } = [];
    public IEnumerable<SystemAttributeDto> SystemAttributes { get; set; } = [];
    public IEnumerable<SystemPartAttributeDto> SystemPartAttributes { get; set; } = [];
    public IEnumerable<UnitSetDto> Units { get; set; } = [];
}
