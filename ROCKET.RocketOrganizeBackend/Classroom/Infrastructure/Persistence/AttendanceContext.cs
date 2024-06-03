namespace ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Persistence;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

public class AttendanceContext: DbContext
{
    public AttendanceContext(DbContextOptions<AttendanceContext> options) : base(options) { }

    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Grade> Floors { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<ClassroomByFloor> ClassroomsByFloor { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<ClassroomByCourse> ClassroomsByCourse { get; set; }
}