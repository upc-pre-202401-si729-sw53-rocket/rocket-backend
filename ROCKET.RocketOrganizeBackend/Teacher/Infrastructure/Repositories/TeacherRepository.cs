namespace ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TeacherRepository
{
    private readonly TeacherContext _context;

    public TeacherRepository(TeacherContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
    {
        return await _context.Teachers.ToListAsync();
    }

    public async Task<Teacher> GetTeacherByIdAsync(int teacherId)
    {
        return await _context.Teachers.FindAsync(teacherId);
    }

    public async Task AddTeacherAsync(Teacher teacher)
    {
        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTeacherAsync(Teacher teacher)
    {
        _context.Teachers.Update(teacher);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTeacherAsync(int teacherId)
    {
        var teacher = await _context.Teachers.FindAsync(teacherId);
        if (teacher != null)
        {
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<bool> EmailTeacherExistsAsync(string email)
    {
        return await _context.Teachers.AnyAsync(t => t.Email == email);
    }
}