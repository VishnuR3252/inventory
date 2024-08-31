namespace InventoryService.Application.Mapping;

using InventoryService.Contracts.Units;
using InventoryService.Domain.Entities;
using Mapster;

public static class MappingConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<UnitDto, Unit>.NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.ConversionUnitId, src => src.ConversionUnitId)
            .Map(dest => dest.ConversionValue, src => src.ConversionValue)
            .Map(dest => dest.IsBaseUnit, src => src.IsBaseUnit);

        TypeAdapterConfig<Unit, UnitResponse>.NewConfig()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.ConversionUnitId, src => src.ConversionUnitId)
            .Map(dest => dest.ConversionValue, src => src.ConversionValue)
            .Map(dest => dest.IsBaseUnit, src => src.IsBaseUnit)
            .Map(dest => dest.CreatedBy, src => src.CreatedBy)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt);
    }
}