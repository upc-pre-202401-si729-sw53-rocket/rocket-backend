namespace ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using System.Threading.Tasks;

public class ClassroomCommandService
{
    private readonly ClassroomRepository _repository;

    public ClassroomCommandService(ClassroomRepository repository)
    {
        _repository = repository;
    }

    public async Task AddClassroomAsync(Classroom classroom)
    {
        await _repository.AddClassroomAsync(classroom);
    }

    public async Task UpdateClassroomAsync(Classroom classroom)
    {
        await _repository.UpdateClassroomAsync(classroom);
    }

    public async Task DeleteClassroomAsync(int id)
    {
        await _repository.DeleteClassroomAsync(id);
    }
}