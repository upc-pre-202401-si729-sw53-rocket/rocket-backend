namespace ROCKET.RocketOrganizeBackend.Teacher.Interfaces.Rest.Resources;
using ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class InfrastructureReportController : ControllerBase
{
    private readonly InfrastructureReportQueryService queryService;
    private readonly InfrastructureReportCommandService commandService;

    public InfrastructureReportController(InfrastructureReportQueryService queryService, InfrastructureReportCommandService commandService)
    {
        this.queryService = queryService;
        this.commandService = commandService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<InfrastructureReport>>> GetInfrastructureReports()
    {
        var infrastructureReports = await queryService.GetAllInfrastructureReportsAsync();
        return Ok(infrastructureReports);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InfrastructureReport>> GetInfrastructureReport(int id)
    {
        var infrastructureReport = await queryService.GetInfrastructureReportByIdAsync(id);
        if (infrastructureReport == null)
        {
            return NotFound();
        }
        return Ok(infrastructureReport);
    }

    [HttpPost]
    public async Task<ActionResult<InfrastructureReport>> PostInfrastructureReport(InfrastructureReport infrastructureReport)
    {
        await commandService.AddInfrastructureReportAsync(infrastructureReport);
        return CreatedAtAction(nameof(GetInfrastructureReport), new { id = infrastructureReport.IdInfrastructureReport }, infrastructureReport);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutInfrastructureReport(int id, InfrastructureReport infrastructureReport)
    {
        if (id != infrastructureReport.IdInfrastructureReport)
        {
            return BadRequest();
        }
        await commandService.UpdateInfrastructureReportAsync(infrastructureReport);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInfrastructureReport(int id)
    {
        await commandService.DeleteInfrastructureReportAsync(id);
        return NoContent();
    }
}