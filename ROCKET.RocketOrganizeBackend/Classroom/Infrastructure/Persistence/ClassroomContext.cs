namespace ROCKET.RocketOrganizeBackend.Classroom.Infrastructure.Persistence;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

public class ClassroomContext : DbContext
{
    public ClassroomContext(DbContextOptions<ClassroomContext> options) : base(options) { }

    public DbSet<Pavilion> Pavilions { get; set; }
    public DbSet<Floor> Floors { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<ClassroomByFloor> ClassroomsByFloor { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<ClassroomByCourse> ClassroomsByCourse { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Course>()
            .HasKey(c => new { c.IdCourse, c.IdSection });
        
        modelBuilder.Entity<Floor>()
            .HasOne(f => f.Pavilion)
            .WithMany(p => p.Floors)
            .HasForeignKey(f => f.PavilionId);
        
        modelBuilder.Entity<ClassroomByFloor>()
            .HasKey(cf => new { cf.FloorId, cf.ClassroomId });

        modelBuilder.Entity<ClassroomByCourse>()
            .HasKey(cc => new { cc.ClassroomId, cc.CourseId, cc.SectionId });
    }
}
