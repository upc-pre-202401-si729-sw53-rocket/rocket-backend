namespace ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using System.Threading.Tasks;

public class FloorCommandService
{
    private readonly FloorRepository _repository;

    public FloorCommandService(FloorRepository repository)
    {
        _repository = repository;
    }

    public async Task AddFloorAsync(Floor floor)
    {
        await _repository.AddFloorAsync(floor);
    }

    public async Task UpdateFloorAsync(Floor floor)
    {
        await _repository.UpdateFloorAsync(floor);
    }

    public async Task DeleteFloorAsync(int id)
    {
        await _repository.DeleteFloorAsync(id);
    }
}