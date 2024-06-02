namespace ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ClassroomQueryService
{
    private readonly ClassroomRepository _repository;

    public ClassroomQueryService(ClassroomRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Classroom>> GetAllClassroomsAsync()
    {
        return await _repository.GetAllClassroomsAsync();
    }

    public async Task<Classroom> GetClassroomByIdAsync(int id)
    {
        return await _repository.GetClassroomByIdAsync(id);
    }
}