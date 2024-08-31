namespace InventoryService.Application.Interfaces.IServices;

using InventoryService.Contracts.Units;

public interface IUnitService
{
    Task<UnitResponse> AddUnitAsync(UnitDto request);
    Task<UnitResponse> UpdateUnitAsync(UnitDto request, long id);
    Task<IEnumerable<UnitResponse>> GetAllAsync();
}
