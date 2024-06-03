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
public class GradesController : ControllerBase
{
    private readonly GradeQueryService _queryService;
    private readonly GradeCommandService _commandService;

    public GradesController(GradeQueryService queryService, GradeCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
    {
        var floors = await _queryService.GetAllGradesAsync();
        return Ok(floors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Grade>> GetGrade(int id)
    {
        var grade = await _queryService.GetGradeByIdAsync(id);
        if (grade == null)
        {
            return NotFound();
        }
        return Ok(grade);
    }

    [HttpPost]
    public async Task<ActionResult<Grade>> CreateGrade(Grade grade)
    {
        await _commandService.AddGradeAsync(grade);
        return CreatedAtAction(nameof(GetGrade), new { id = grade.IdGrade }, grade);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGrade(int id, Grade grade)
    {
        if (id != grade.IdGrade)
        {
            return BadRequest();
        }

        await _commandService.UpdateGradeAsync(grade);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGrade(int id)
    {
        await _commandService.DeleteGradeAsync(id);
        return NoContent();
    }
}