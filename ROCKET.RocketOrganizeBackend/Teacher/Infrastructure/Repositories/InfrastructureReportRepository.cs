namespace ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class InfrastructureReportRepository
{
    private readonly InfrastructureReportContext _context;

    public InfrastructureReportRepository(InfrastructureReportContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<InfrastructureReport>> GetAllInfrastructureReportsAsync()
    {
        return await _context.InfrastructureReports.ToListAsync();
    }

    public async Task<InfrastructureReport> GetInfrastructureReportByIdAsync(int InfrastructureReportId)
    {
        return await _context.InfrastructureReports.FindAsync(InfrastructureReportId);
    }

    public async Task AddInfrastructureReportAsync(InfrastructureReport infrastructureReport)
    {
        _context.InfrastructureReports.Add(infrastructureReport);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateInfrastructureReportAsync(InfrastructureReport infrastructureReport)
    {
        _context.InfrastructureReports.Update(infrastructureReport);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteInfrastructureReportAsync(int infrastructureReportId)
    {
        var infrastructureReport = await _context.InfrastructureReports.FindAsync(infrastructureReportId);
        if (infrastructureReport != null)
        {
            _context.InfrastructureReports.Remove(infrastructureReport);
            await _context.SaveChangesAsync();
        }
    }
}