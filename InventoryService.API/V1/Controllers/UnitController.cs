namespace InventoryService.API.V1.Controllers;

using Microsoft.AspNetCore.Mvc;
using InventoryService.Application.Interfaces.IServices;
using InventoryService.Contracts.Units;
using CommonService.Constants;
using InventoryService.API.Constants;

[ApiController]
[Route(ApiConstants.APIPrefix + "/units")]
[ApiVersion("1.0")]
public class UnitController(IUnitService unitService) : ControllerBase
{
    private readonly IUnitService _unitService = unitService ?? throw new ArgumentNullException(nameof(unitService));

    [HttpPost("create")]
    public async Task<IActionResult> AddUnitAsync(UnitDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var savedUnit = await _unitService.AddUnitAsync(request);
        return StatusCode(StatusCodes.Status201Created, savedUnit);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateUnitAsync(UnitDto request, long id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var savedUnit = await _unitService.UpdateUnitAsync(request, id);
        return Ok(savedUnit);
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetAllUnitsAsync()
    {
        var units = await _unitService.GetAllAsync();
        return Ok(units);
    }
}