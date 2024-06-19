namespace ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using System.Threading.Tasks;

public class AdministratorCommandService
{
    private readonly AdministratorRepository repository;

    public AdministratorCommandService(AdministratorRepository repository)
    {
        this.repository = repository;
    }

    public async Task AddAdministratorAsync(Administrator administrator)
    {
        if (await repository.EmaiAdministratorExistsAsync(administrator.Email))
        {
            throw new ArgumentException("An administrator with this email already exists.");
        }
        await repository.AddAdministratorAsync(administrator);
    }

    public async Task UpdateAdministratorAsync(Administrator administrator)
    {
        await repository.UpdateAdministratorAsync(administrator);
    }

    public async Task DeleteAdministratorAsync(int administratorId)
    {
        await repository.DeleteAdministratorAsync(administratorId);
    }
}