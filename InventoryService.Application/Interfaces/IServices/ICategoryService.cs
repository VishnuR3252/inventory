namespace InventoryService.Application.Interfaces.IServices;

public interface ICategoryService
{
    Task<CategoryResponse> AddCategoryAsync(CategoryDto request);
}