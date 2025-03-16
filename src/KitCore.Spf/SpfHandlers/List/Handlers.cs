using KitCore.Domain.Dto;
using KitCore.Domain.Repository;

namespace KitCore.Spf.SpfHandlers.List;

public class Brand(IRepository<BrandSetDto> repository) : KitCoreListPromptHandler<BrandSetDto>(repository) { }
public class System(IRepository<SystemDto> repository) : KitCoreListPromptHandler<SystemDto>(repository) { }
public class Model(IRepository<ModelSetDto> repository) : KitCoreListPromptHandler<ModelSetDto>(repository) { }
public class Unit(IRepository<UnitSetDto> repository) : KitCoreListPromptHandler<UnitSetDto>(repository) { }

