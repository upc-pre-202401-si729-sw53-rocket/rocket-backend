namespace ROCKET.RocketOrganizeBackend.Student.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Infrastructure.Repositories;
using System.Threading.Tasks;

public class GuardianCommandService
{
    private readonly GuardianRepository _repository;

    public GuardianCommandService(GuardianRepository repository)
    {
        _repository = repository;
    }

    public async Task AddGuardianAsync(Guardian guardian)
    {
        await _repository.AddGuardianAsync(guardian);
    }

    public async Task UpdateGuardianAsync(Guardian guardian)
    {
        await _repository.UpdateGuardianAsync(guardian);
    }

    public async Task DeleteGuardianAsync(int id)
    {
        await _repository.DeleteGuardianAsync(id);
    }
}