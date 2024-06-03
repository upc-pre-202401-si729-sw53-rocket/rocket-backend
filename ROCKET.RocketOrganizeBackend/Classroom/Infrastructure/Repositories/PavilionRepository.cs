namespace ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PavilionRepository
{
    private readonly PavilionContext _context;

    public PavilionRepository(PavilionContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pavilion>> GetAllPavilionsAsync()
    {
        return await _context.Pavilions.ToListAsync();
    }

    public async Task<Pavilion> GetPavilionByIdAsync(int id)
    {
        return await _context.Pavilions.FindAsync(id);
    }

    public async Task AddPavilionAsync(Pavilion pavilion)
    {
        _context.Pavilions.Add(pavilion);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePavilionAsync(Pavilion pavilion)
    {
        _context.Entry(pavilion).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeletePavilionAsync(int id)
    {
        var pavilion = await _context.Pavilions.FindAsync(id);
        if (pavilion != null)
        {
            _context.Pavilions.Remove(pavilion);
            await _context.SaveChangesAsync();
        }
    }
}