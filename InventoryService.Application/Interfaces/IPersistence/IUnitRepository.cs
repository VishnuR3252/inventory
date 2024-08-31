namespace InventoryService.Application.Interfaces.IPersistence;

using System.Collections.Generic;
using System.Threading.Tasks;
namspace InventoryService.Domain.Entities;

public interface IUnitRepository
{
    Task AddUnitAsync(Unit unit);
    Task UpdateUnitAsync(Unit unit);
    IQueryable<Unit> GetAllUnits();
}
