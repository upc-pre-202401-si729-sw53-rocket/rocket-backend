namespace ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class AttendanceRepository
{
    private readonly AttendanceContext _context;

    public AttendanceRepository(AttendanceContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
    {
        return await _context.Attendances.ToListAsync();
    }

    public async Task<Attendance> GetAttendanceByIdAsync(int id)
    {
        return await _context.Attendances.FindAsync(id);
    }

    public async Task AddAttendanceAsync(Attendance attendance)
    {
        _context.Attendances.Add(attendance);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAttendanceAsync(Attendance attendance)
    {
        _context.Entry(attendance).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAttendanceAsync(int id)
    {
        var attendance = await _context.Attendances.FindAsync(id);
        if (attendance != null)
        {
            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
        }
    }
}