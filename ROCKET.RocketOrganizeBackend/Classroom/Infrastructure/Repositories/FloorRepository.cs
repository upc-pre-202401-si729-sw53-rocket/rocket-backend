namespace ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FloorRepository
{
    private readonly FloorContext _context;

    public FloorRepository(FloorContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Floor>> GetAllFloorsAsync()
    {
        return await _context.Floors.ToListAsync();
    }

    public async Task<Floor> GetFloorByIdAsync(int id)
    {
        return await _context.Floors.FindAsync(id);
    }

    public async Task AddFloorAsync(Floor floor)
    {
        _context.Floors.Add(floor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateFloorAsync(Floor floor)
    {
        _context.Entry(floor).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFloorAsync(int id)
    {
        var floor = await _context.Floors.FindAsync(id);
        if (floor != null)
        {
            _context.Floors.Remove(floor);
            await _context.SaveChangesAsync();
        }
    }
}