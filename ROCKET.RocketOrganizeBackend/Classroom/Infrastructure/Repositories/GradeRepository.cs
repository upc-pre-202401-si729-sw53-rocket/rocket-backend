namespace ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GradeRepository
{
    private readonly GradeContext _context;

    public GradeRepository(GradeContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Grade>> GetAllGradesAsync()
    {
        return await _context.Grades.ToListAsync();
    }

    public async Task<Grade> GetGradeByIdAsync(int id)
    {
        return await _context.Grades.FindAsync(id);
    }

    public async Task AddGradeAsync(Grade grade)
    {
        _context.Grades.Add(grade);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateGradeAsync(Grade grade)
    {
        _context.Entry(grade).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGradeAsync(int id)
    {
        var grade = await _context.Grades.FindAsync(id);
        if (grade != null)
        {
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
        }
    }
}