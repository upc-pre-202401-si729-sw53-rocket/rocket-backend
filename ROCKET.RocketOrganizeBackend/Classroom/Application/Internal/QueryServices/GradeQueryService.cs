namespace ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GradeQueryService
{
    private readonly GradeRepository _repository;

    public GradeQueryService(GradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Grade>> GetAllGradesAsync()
    {
        return await _repository.GetAllGradesAsync();
    }

    public async Task<Grade> GetGradeByIdAsync(int id)
    {
        return await _repository.GetGradeByIdAsync(id);
    }
}