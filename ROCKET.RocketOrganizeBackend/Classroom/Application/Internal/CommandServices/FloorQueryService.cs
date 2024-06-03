namespace ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FloorQueryService
{
    private readonly FloorRepository _repository;

    public FloorQueryService(FloorRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Floor>> GetAllFloorsAsync()
    {
        return await _repository.GetAllFloorsAsync();
    }

    public async Task<Floor> GetFloorByIdAsync(int id)
    {
        return await _repository.GetFloorByIdAsync(id);
    }
}