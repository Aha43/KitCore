using System;

namespace KitCore.Domain.Dto;

// Project: KitCore.Domain


public class SystemDto
{
    public string Id { get; set; } = null!;  // Unique identifier (GUID)
    public string Code { get; set; } = null!;  // Human-friendly code for labeling and referencing
    public string? UserId { get; set; }  // Optional for future multi-user support
    public string Name { get; set; } = null!;
    public string SystemTypeName { get; set; } = null!;  // FK to SystemTypeSet
    public string Brand { get; set; } = null!;  // FK to BrandSet
    public string Model { get; set; } = null!;  // FK to ModelSet
    public bool IsConfiguration { get; set; }
    public string Notes { get; set; } = null!;
}

public class SystemPartDto
{
    public string Id { get; set; } = null!;  // Unique identifier (GUID)
    public string Code { get; set; } = null!;  // Human-friendly code for labeling and referencing
    public string? UserId { get; set; }  // Optional for future multi-user support
    public string Name { get; set; } = null!;
    public string SystemPartTypeName { get; set; } = null!;  // FK to SystemPartTypeSet
    public string Brand { get; set; } = null!;  // FK to BrandSet
    public string Model { get; set; } = null!;  // FK to ModelSet
    public string Notes { get; set; } = null!;
}

public class PurchaseDto
{
    public string Id { get; set; } = null!;
    public string? UserId { get; set; }  // Optional for future multi-user support
    public DateTime PurchaseDate { get; set; }
    public string CurrencyId { get; set; } = null!;  // FK to CurrencySet
    public string PaidCurrencyId { get; set; } = null!;  // FK to CurrencySet
    public double ConversionFactor { get; set; }
    public double Price { get; set; }
    public double? ShipmentCost { get; set; }
    public double? Vat { get; set; }
    public string Notes { get; set; } = null!;
}

public class UseCaseDto
{
    public string Id { get; set; } = null!;
    public string? UserId { get; set; }  // Optional for future multi-user support
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}

public class UseCaseStepDto
{
    public string Id { get; set; } = null!;
    public string Description { get; set; } = null!;
}

public class UseCaseStepAssignmentDto
{
    public string Id { get; set; } = null!;
    public string UseCaseId { get; set; } = null!;  // FK to UseCase
    public string UseCaseStepId { get; set; } = null!;  // FK to UseCaseStep
    public int StepNumber { get; set; }
    public string Description { get; set; } = null!;
}

public abstract class BaseAttributeDto
{
    public string Id { get; set; } = null!;
    public string AttributeValueId { get; set; } = null!;  // FK to AttributeValue
    public string? Description { get; set; }  // Optional description for specific usage
}

public class SystemAttributeDto : BaseAttributeDto
{
    public string SystemId { get; set; } = null!;  // FK to System
}

public class SystemPartAttributeDto : BaseAttributeDto
{
    public string SystemPartId { get; set; } = null!;  // FK to SystemPart
}

public class AttributeTypeDto
{
    public string Name { get; set; } = null!;  // Primary Key
    public string DataType { get; set; } = null!;  // FK to DataTypeSet
    public string? Unit { get; set; }  // FK to UnitSet, nullable for dimensionless attributes
}

public class AttributeValueDto
{
    public string Id { get; set; } = null!;
    public string AttributeTypeName { get; set; } = null!;  // FK to AttributeType
    public string Value { get; set; } = null!;  // Stored as text
}

public class SystemTypeDto
{
    public string Name { get; set; } = null!;  // Primary Key
    public string Description { get; set; } = null!;
}

public class SystemPartTypeDto
{
    public string Name { get; set; } = null!;  // Primary Key
    public string Description { get; set; } = null!;
}

public class SystemTypeAttributeTypeDto
{
    public string Id { get; set; } = null!;
    public string SystemTypeName { get; set; } = null!;  // FK to SystemType
    public string AttributeTypeName { get; set; } = null!;  // FK to AttributeType
}

public class SystemPartTypeAttributeTypeDto
{
    public string Id { get; set; } = null!;
    public string SystemPartTypeName { get; set; } = null!;  // FK to SystemPartType
    public string AttributeTypeName { get; set; } = null!;  // FK to AttributeType
}

// Set Tables
public class BrandSetDto
{
    public string Name { get; set; } = null!;  // Primary Key
    public string? Uri { get; set; }
}

public class CurrencySetDto
{
    public string Currency { get; set; } = null!;  // Primary Key
}

public class ModelSetDto
{
    public string Model { get; set; } = null!;  // Primary Key
}

public class DataTypeSetDto
{
    public string DataType { get; set; } = null!;  // Primary Key
}

public class UnitSetDto
{
    public string Name { get; set; } = null!;  // Primary Key
    public string Symbol { get; set; } = null!;
    public decimal Factor { get; set; }
}
