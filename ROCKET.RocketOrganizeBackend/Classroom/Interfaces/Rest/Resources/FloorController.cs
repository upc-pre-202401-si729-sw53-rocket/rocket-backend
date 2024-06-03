namespace ROCKET.RocketOrganizeBackend.Classroom.Interfaces.Rest.Resources;
using ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class FloorsController : ControllerBase
{
    private readonly FloorQueryService _queryService;
    private readonly FloorCommandService _commandService;

    public FloorsController(FloorQueryService queryService, FloorCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Floor>>> GetFloors()
    {
        var floors = await _queryService.GetAllFloorsAsync();
        return Ok(floors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Floor>> GetFloor(int id)
    {
        var floor = await _queryService.GetFloorByIdAsync(id);
        if (floor == null)
        {
            return NotFound();
        }
        return Ok(floor);
    }

    [HttpPost]
    public async Task<ActionResult<Floor>> CreateFloor(Floor floor)
    {
        await _commandService.AddFloorAsync(floor);
        return CreatedAtAction(nameof(GetFloor), new { id = floor.IdFloor }, floor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFloor(int id, Floor floor)
    {
        if (id != floor.IdFloor)
        {
            return BadRequest();
        }

        await _commandService.UpdateFloorAsync(floor);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFloor(int id)
    {
        await _commandService.DeleteFloorAsync(id);
        return NoContent();
    }
}