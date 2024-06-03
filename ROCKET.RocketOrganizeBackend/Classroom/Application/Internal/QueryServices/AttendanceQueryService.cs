namespace ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using System.Threading.Tasks;

public class AttendanceQueryService
{
    private readonly AttendanceRepository _repository;

    public AttendanceQueryService(AttendanceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
    {
        return await _repository.GetAllAttendancesAsync();
    }

    public async Task<Attendance> GetAttendanceByIdAsync(int id)
    {
        return await _repository.GetAttendanceByIdAsync(id);
    }
}