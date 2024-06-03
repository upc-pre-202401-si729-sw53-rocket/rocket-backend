namespace ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AdministratorQueryService
{
    private readonly AdministratorRepository repository;

    public AdministratorQueryService(AdministratorRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<Administrator>> GetAllAdministratorsAsync()
    {
        return await repository.GetAllAdministratorsAsync();
    }

    public async Task<Administrator> GetAdministratorByIdAsync(int id)
    {
        return await repository.GetAdministratorByIdAsync(id);
    }
}