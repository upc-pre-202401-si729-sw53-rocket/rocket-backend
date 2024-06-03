namespace ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public class InfrastructureReportQueryService
{
    private readonly InfrastructureReportRepository repository;

    public InfrastructureReportQueryService(InfrastructureReportRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<InfrastructureReport>> GetAllInfrastructureReportsAsync()
    {
        return await repository.GetAllInfrastructureReportsAsync();
    }

    public async Task<InfrastructureReport> GetInfrastructureReportByIdAsync(int id)
    {
        return await repository.GetInfrastructureReportByIdAsync(id);
    }
}