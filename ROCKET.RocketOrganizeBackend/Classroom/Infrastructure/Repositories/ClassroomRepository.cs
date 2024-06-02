namespace ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ClassroomRepository
{
    private readonly ClassroomContext _context;

    public ClassroomRepository(ClassroomContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Classroom>> GetAllClassroomsAsync()
    {
        return await _context.Classrooms.ToListAsync();
    }

    public async Task<Classroom> GetClassroomByIdAsync(int id)
    {
        return await _context.Classrooms.FindAsync(id);
    }

    public async Task AddClassroomAsync(Classroom classroom)
    {
        _context.Classrooms.Add(classroom);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateClassroomAsync(Classroom classroom)
    {
        _context.Entry(classroom).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteClassroomAsync(int id)
    {
        var classroom = await _context.Classrooms.FindAsync(id);
        if (classroom != null)
        {
            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();
        }
    }
}