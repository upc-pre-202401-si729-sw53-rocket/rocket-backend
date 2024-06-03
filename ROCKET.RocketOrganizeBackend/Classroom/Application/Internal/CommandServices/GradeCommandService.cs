namespace ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using System.Threading.Tasks;

public class GradeCommandService
{
    private readonly GradeRepository _repository;

    public GradeCommandService(GradeRepository repository)
    {
        _repository = repository;
    }

    public async Task AddGradeAsync(Grade grade)
    {
        await _repository.AddGradeAsync(grade);
    }

    public async Task UpdateGradeAsync(Grade grade)
    {
        await _repository.UpdateGradeAsync(grade);
    }

    public async Task DeleteGradeAsync(int id)
    {
        await _repository.DeleteGradeAsync(id);
    }
}