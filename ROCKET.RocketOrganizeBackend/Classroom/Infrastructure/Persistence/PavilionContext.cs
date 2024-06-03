namespace ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Persistence;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

public class PavilionContext: DbContext
{
    public PavilionContext(DbContextOptions<PavilionContext> options) : base(options) { }

    public DbSet<Pavilion> Pavilions { get; set; }
    public DbSet<Floor> Floors { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<ClassroomByFloor> ClassroomsByFloor { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<ClassroomByCourse> ClassroomsByCourse { get; set; }
}