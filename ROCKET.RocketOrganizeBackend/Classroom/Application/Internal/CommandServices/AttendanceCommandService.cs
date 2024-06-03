namespace ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AttendanceCommandService
{
    private readonly AttendanceRepository _repository;

    public AttendanceCommandService(AttendanceRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAttendanceAsync(Attendance attendance)
    {
        await _repository.AddAttendanceAsync(attendance);
    }

    public async Task UpdateAttendanceAsync(Attendance attendance)
    {
        await _repository.UpdateAttendanceAsync(attendance);
    }

    public async Task DeleteAttendanceAsync(int id)
    {
        await _repository.DeleteAttendanceAsync(id);
    }
}