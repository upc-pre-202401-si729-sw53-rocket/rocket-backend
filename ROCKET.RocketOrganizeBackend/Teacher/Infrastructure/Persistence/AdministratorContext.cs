namespace ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Persistence;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

public class AdministratorContext : DbContext
{
    public AdministratorContext(DbContextOptions<AdministratorContext> options) : base(options) { }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<InfrastructureReport> InfrastructureReports { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<InventoryRequest> InventoryRequests { get; set; }
    public DbSet<TeacherByCourse> TeachersByCourse { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure primary keys
        modelBuilder.Entity<Course>().HasKey(c => new { c.IdCourse, c.IdSection });
        modelBuilder.Entity<TeacherByCourse>().HasKey(tc => new { tc.Id });
        modelBuilder.Entity<InventoryRequest>().HasKey(ir => new { ir.Id, ir.InventoryId, ir.TeacherId, ir.AdministratorId });

        // Configure relationships, foreign keys, etc. if needed
        modelBuilder.Entity<InfrastructureReport>()
            .HasOne(ir => ir.Teacher)
            .WithMany(t => t.InfrastructureReport) 
            .HasForeignKey(ir => ir.TeacherId);

        modelBuilder.Entity<InventoryRequest>()
            .HasOne(ir => ir.Inventory)
            .WithMany()
            .HasForeignKey(ir => ir.InventoryId);

        modelBuilder.Entity<InventoryRequest>()
            .HasOne(ir => ir.Teacher)
            .WithMany(t => t.InventoryRequest)
            .HasForeignKey(ir => ir.TeacherId);

        modelBuilder.Entity<InventoryRequest>()
            .HasOne(ir => ir.Administrator)
            .WithMany()
            .HasForeignKey(ir => ir.AdministratorId);

        modelBuilder.Entity<TeacherByCourse>()
            .HasOne(tc => tc.Teacher)
            .WithMany(t => t.TeacherByCourse)
            .HasForeignKey(tc => tc.TeacherId);

        modelBuilder.Entity<TeacherByCourse>()
            .HasOne(tc => tc.Course)
            .WithMany(c => c.TeacherByCourse)
            .HasForeignKey(tc => new { tc.CourseId, tc.SectionId });
        
        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Course)
            .WithMany() // Indica que un curso puede tener muchas asistencias
            .HasForeignKey(a => a.CourseId); // Establece la clave externa para CourseId

        
    }
}