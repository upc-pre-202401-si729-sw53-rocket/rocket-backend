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
public class PavilionsController : ControllerBase
{
    private readonly PavilionQueryService _queryService;
    private readonly PavilionCommandService _commandService;

    public PavilionsController(PavilionQueryService queryService, PavilionCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pavilion>>> GetPavilions()
    {
        var pavilions = await _queryService.GetAllPavilionsAsync();
        return Ok(pavilions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pavilion>> GetPavilion(int id)
    {
        var pavilion = await _queryService.GetPavilionByIdAsync(id);
        if (pavilion == null)
        {
            return NotFound();
        }
        return Ok(pavilion);
    }

    [HttpPost]
    public async Task<ActionResult<Pavilion>> CreateClassroom(Pavilion pavilion)
    {
        await _commandService.AddPavilionAsync(pavilion);
        return CreatedAtAction(nameof(GetPavilion), new { id = pavilion.IdPavilion }, pavilion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClassroom(int id, Pavilion pavilion)
    {
        if (id != pavilion.IdPavilion)
        {
            return BadRequest();
        }

        await _commandService.UpdatePavilionAsync(pavilion);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePavilion(int id)
    {
        await _commandService.DeletePavilionAsync(id);
        return NoContent();
    }
}