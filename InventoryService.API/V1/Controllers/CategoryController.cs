using InventoryService.API.Constants;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route(ApiConstants.APIPrefix + "/units")]
[ApiVersion("1.0")]

public class CategoryController(ICategoryService categoryService) : ControllerBase
{
   private readonly ICategoryService _categoryservice = categoryService ?? throw new ArgumentNullException(nameof(categoryService));

    [HttpPost("AddCategory")]
    public async Task<IActionResult> AddCategoryAsync(CategoryDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var savedCategory = await _categoryservice.AddCategoryAsync(request);
        return StatusCode(StatusCodes.Status201Created, savedCategory);
    }
}