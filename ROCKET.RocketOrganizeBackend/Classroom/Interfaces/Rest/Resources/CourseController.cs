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
public class CoursesController : ControllerBase
{
    private readonly CourseQueryService _queryService;
    private readonly CourseCommandService _commandService;

    public CoursesController(CourseQueryService queryService, CourseCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
    {
        var courses = await _queryService.GetAllCoursesAsync();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> GetCourse(int id)
    {
        var course = await _queryService.GetCourseByIdAsync(id);
        if (course == null)
        {
            return NotFound();
        }

        return Ok(course);
    }

    [HttpPost]
    public async Task<ActionResult<Course>> CreateCourse(Course course)
    {
        await _commandService.AddCourseAsync(course);
        return CreatedAtAction(nameof(GetCourse), new { id = course.IdCourse }, course);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(int id, Course course)
    {
        if (id != course.IdCourse)
        {
            return BadRequest();
        }

        await _commandService.UpdateCourseAsync(course);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        await _commandService.DeleteCourseAsync(id);
        return NoContent();
    }
}