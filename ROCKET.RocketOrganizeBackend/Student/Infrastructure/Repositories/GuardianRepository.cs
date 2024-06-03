namespace ROCKET.RocketOrganizeBackend.Student.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GuardianRepository
{
    private readonly GuardianContext _context;

    public GuardianRepository(GuardianContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Guardian>> GetAllGuardiansAsync()
    {
        return await _context.Guardians.ToListAsync();
    }

    public async Task<Guardian> GetGuardianByIdAsync(int id)
    {
        return await _context.Guardians.FindAsync(id);
    }

    public async Task AddGuardianAsync(Guardian guardian)
    {
        _context.Guardians.Add(guardian);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateGuardianAsync(Guardian guardian)
    {
        _context.Entry(guardian).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGuardianAsync(int id)
    {
        var guardian = await _context.Guardians.FindAsync(id);
        if (guardian != null)
        {
            _context.Guardians.Remove(guardian);
            await _context.SaveChangesAsync();
        }
    }
}