namespace ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CourseRepository
{
    private readonly CourseContext _context;

    public CourseRepository(CourseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task<Course> GetCourseByIdAsync(int id)
    {
        return await _context.Courses.FindAsync(id);
    }

    public async Task AddCourseAsync(Course course)
    {
        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCourseAsync(Course course)
    {
        _context.Entry(course).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCourseAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course != null)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}