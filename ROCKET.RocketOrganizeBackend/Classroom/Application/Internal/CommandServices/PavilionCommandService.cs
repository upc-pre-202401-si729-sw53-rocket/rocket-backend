namespace ROCKET.RocketOrganizeBackend.Classroom.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PavilionCommandService
{
    private readonly PavilionRepository _repository;

    public PavilionCommandService(PavilionRepository repository)
    {
        _repository = repository;
    }

    public async Task AddPavilionAsync(Pavilion pavilion)
    {
        await _repository.AddPavilionAsync(pavilion);
    }

    public async Task UpdatePavilionAsync(Pavilion pavilion)
    {
        await _repository.UpdatePavilionAsync(pavilion);
    }

    public async Task DeletePavilionAsync(int id)
    {
        await _repository.DeletePavilionAsync(id);
    }
}