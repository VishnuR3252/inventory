namespace InventoryService.Application.Interfaces.IPersistence;

public interface ICategoryRepository
{
  Task AddCategoryAsync(Category category);  
}