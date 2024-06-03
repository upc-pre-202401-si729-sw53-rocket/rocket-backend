namespace ROCKET.RocketOrganizeBackend.Teacher.Interfaces.Rest.Resources;
using ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AdministratorController : ControllerBase
{
    private readonly AdministratorQueryService queryService;
    private readonly AdministratorCommandService commandService;

    public AdministratorController(AdministratorQueryService queryService, AdministratorCommandService commandService)
    {
        this.queryService = queryService;
        this.commandService = commandService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Administrator>>> GetAdministrators()
    {
        var administrators = await queryService.GetAllAdministratorsAsync();
        return Ok(administrators);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Administrator>> GetAdministrator(int id)
    {
        var administrator = await queryService.GetAdministratorByIdAsync(id);
        if (administrator == null)
        {
            return NotFound();
        }
        return Ok(administrator);
    }

    [HttpPost]
    public async Task<ActionResult<Administrator>> PostAdministrator(Administrator administrator)
    {
        await commandService.AddAdministratorAsync(administrator);
        return CreatedAtAction(nameof(GetAdministrator), new { id = administrator.IdAdministrator }, administrator);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAdministrator(int id, Administrator administrator)
    {
        if (id != administrator.IdAdministrator)
        {
            return BadRequest();
        }
        await commandService.UpdateAdministratorAsync(administrator);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdministrator(int id)
    {
        await commandService.DeleteAdministratorAsync(id);
        return NoContent();
    }
}