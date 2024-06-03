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
public class AttendancesController : ControllerBase
{
    private readonly AttendanceQueryService _queryService;
    private readonly AttendanceCommandService _commandService;

    public AttendancesController(AttendanceQueryService queryService, AttendanceCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendances()
    {
        var pavilions = await _queryService.GetAllAttendancesAsync();
        return Ok(pavilions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Attendance>> GetAttendance(int id)
    {
        var attendance = await _queryService.GetAttendanceByIdAsync(id);
        if (attendance == null)
        {
            return NotFound();
        }
        return Ok(attendance);
    }

    [HttpPost]
    public async Task<ActionResult<Attendance>> CreateClassroom(Attendance attendance)
    {
        await _commandService.AddAttendanceAsync(attendance);
        return CreatedAtAction(nameof(GetAttendance), new { id = attendance.IdAttendance }, attendance);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClassroom(int id, Attendance attendance)
    {
        if (id != attendance.IdAttendance)
        {
            return BadRequest();
        }

        await _commandService.UpdateAttendanceAsync(attendance);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAttendance(int id)
    {
        await _commandService.DeleteAttendanceAsync(id);
        return NoContent();
    }
}