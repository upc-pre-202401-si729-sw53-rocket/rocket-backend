namespace ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using System.Threading.Tasks;

public class PavilionQueryService
{
    private readonly PavilionRepository _repository;

    public PavilionQueryService(PavilionRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Pavilion>> GetAllPavilionsAsync()
    {
        return await _repository.GetAllPavilionsAsync();
    }

    public async Task<Pavilion> GetPavilionByIdAsync(int id)
    {
        return await _repository.GetPavilionByIdAsync(id);
    }
}