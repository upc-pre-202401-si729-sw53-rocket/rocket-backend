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
public class ClassroomsController : ControllerBase
{
    private readonly ClassroomQueryService _queryService;
    private readonly ClassroomCommandService _commandService;

    public ClassroomsController(ClassroomQueryService queryService, ClassroomCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Classroom>>> GetClassrooms()
    {
        var classrooms = await _queryService.GetAllClassroomsAsync();
        return Ok(classrooms);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Classroom>> GetClassroom(int id)
    {
        var classroom = await _queryService.GetClassroomByIdAsync(id);
        if (classroom == null)
        {
            return NotFound();
        }
        return Ok(classroom);
    }

    [HttpPost]
    public async Task<ActionResult<Classroom>> CreateClassroom(Classroom classroom)
    {
        await _commandService.AddClassroomAsync(classroom);
        return CreatedAtAction(nameof(GetClassroom), new { id = classroom.IdClassroom }, classroom);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClassroom(int id, Classroom classroom)
    {
        if (id != classroom.IdClassroom)
        {
            return BadRequest();
        }

        await _commandService.UpdateClassroomAsync(classroom);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClassroom(int id)
    {
        await _commandService.DeleteClassroomAsync(id);
        return NoContent();
    }
}