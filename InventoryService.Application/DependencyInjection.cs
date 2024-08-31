namespace InventoryService.Application;

using Microsoft.Extensions.DependencyInjection;
using InventoryService.Application.Mapping;
using InventoryService.Application.Interfaces.IServices;
using InventoryService.Application.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        MappingConfig.RegisterMappings();

        service.AddScoped<IUnitService, UnitService>();
        return service;
    }
}
