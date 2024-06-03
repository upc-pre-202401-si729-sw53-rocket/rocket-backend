namespace ROCKET.RocketOrganizeBackend.Student.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GuardianQueryService
{
    private readonly GuardianRepository _repository;

    public GuardianQueryService(GuardianRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Guardian>> GetAllGuardiansAsync()
    {
        return await _repository.GetAllGuardiansAsync();
    }

    public async Task<Guardian> GetGuardianByIdAsync(int id)
    {
        return await _repository.GetGuardianByIdAsync(id);
    }
}