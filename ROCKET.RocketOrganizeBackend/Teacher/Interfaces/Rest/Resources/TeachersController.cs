namespace ROCKET.RocketOrganizeBackend.Teacher.Interfaces.Rest.Resources;
using ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly TeacherQueryService queryService;
    private readonly TeacherCommandService commandService;

    public TeacherController(TeacherQueryService queryService, TeacherCommandService commandService)
    {
        this.queryService = queryService;
        this.commandService = commandService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
    {
        var teachers = await queryService.GetAllTeachersAsync();
        return Ok(teachers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Teacher>> GetTeacher(int id)
    {
        var teacher = await queryService.GetTeacherByIdAsync(id);
        if (teacher == null)
        {
            return NotFound();
        }
        return Ok(teacher);
    }

    [HttpPost]
    public async Task<ActionResult<Teacher>> PostTeacher(Teacher teacher)
    {
        await commandService.AddTeacherAsync(teacher);
        return CreatedAtAction(nameof(GetTeacher), new { id = teacher.IdTeacher }, teacher);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTeacher(int id, Teacher teacher)
    {
        if (id != teacher.IdTeacher)
        {
            return BadRequest();
        }
        await commandService.UpdateTeacherAsync(teacher);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        await commandService.DeleteTeacherAsync(id);
        return NoContent();
    }
}