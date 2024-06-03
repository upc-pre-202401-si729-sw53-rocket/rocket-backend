namespace ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AdministratorRepository
{
    private readonly AdministratorContext _context;

    public AdministratorRepository(AdministratorContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Administrator>> GetAllAdministratorsAsync()
    {
        return await _context.Administrators.ToListAsync();
    }

    public async Task<Administrator> GetAdministratorByIdAsync(int administratorId)
    {
        return await _context.Administrators.FindAsync(administratorId);
    }

    public async Task AddAdministratorAsync(Administrator administrator)
    {
        _context.Administrators.Add(administrator);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAdministratorAsync(Administrator administrator)
    {
        _context.Administrators.Update(administrator);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAdministratorAsync(int administratorId)
    {
        var administrator = await _context.Administrators.FindAsync(administratorId);
        if (administrator != null)
        {
            _context.Administrators.Remove(administrator);
            await _context.SaveChangesAsync();
        }
    }
}