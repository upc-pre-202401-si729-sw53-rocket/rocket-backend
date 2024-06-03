namespace ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using System.Threading.Tasks;

public class InfrastructureReportCommandService
{
    private readonly InfrastructureReportRepository repository;

    public InfrastructureReportCommandService(InfrastructureReportRepository repository)
    {
        this.repository = repository;
    }

    public async Task AddInfrastructureReportAsync(InfrastructureReport infrastructureReport)
    {
        await repository.AddInfrastructureReportAsync(infrastructureReport);
    }

    public async Task UpdateInfrastructureReportAsync(InfrastructureReport infrastructureReport)
    {
        await repository.UpdateInfrastructureReportAsync(infrastructureReport);
    }

    public async Task DeleteInfrastructureReportAsync(int infrastructureReportId)
    {
        await repository.DeleteInfrastructureReportAsync(infrastructureReportId);
    }
}