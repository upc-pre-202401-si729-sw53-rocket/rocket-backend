namespace ROCKET.RocketOrganizeBackend.Student.Interfaces.Rest.Resources;
using ROCKET.RocketOrganizeBackend.Student.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Student.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;


[Route("api/[controller]")]
[ApiController]
public class GuardianController : ControllerBase
{
    private readonly GuardianQueryService _queryService;
    private readonly GuardianCommandService _commandService;

    public GuardianController(GuardianQueryService queryService, GuardianCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Guardian>>> GetGuardians()
    {
        var guardians = await _queryService.GetAllGuardiansAsync();
        return Ok(guardians);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Guardian>> GetGuardian(int id)
    {
        var guardian = await _queryService.GetGuardianByIdAsync(id);
        if (guardian == null)
        {
            return NotFound();
        }
        return Ok(guardian);
    }

    [HttpPost]
    public async Task<ActionResult<Guardian>> CreateGuardian(Guardian guardian)
    {
        await _commandService.AddGuardianAsync(guardian);
        return CreatedAtAction(nameof(GetGuardian), new { id = guardian.IdGuardian }, guardian);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGuardian(int id, Guardian guardian)
    {
        if (id != guardian.IdGuardian)
        {
            return BadRequest();
        }

        await _commandService.UpdateGuardianAsync(guardian);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGuardian(int id)
    {
        await _commandService.DeleteGuardianAsync(id);
        return NoContent();
    }
}