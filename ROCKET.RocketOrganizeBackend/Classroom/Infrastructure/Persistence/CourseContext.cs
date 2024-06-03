namespace ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Persistence;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

public class CourseContext : DbContext
{
    public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }

    public DbSet<Attendance> Pavilions { get; set; }
    public DbSet<Grade> Floors { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<ClassroomByFloor> ClassroomsByFloor { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<ClassroomByCourse> ClassroomsByCourse { get; set; }
}