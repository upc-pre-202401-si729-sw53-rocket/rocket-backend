namespace ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Persistence;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

public class TeacherContext : DbContext
{
    public TeacherContext(DbContextOptions<TeacherContext> options) : base(options) { }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<InfrastructureReport> InfrastructureReports { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<InventoryRequest> InventoryRequests { get; set; }
    public DbSet<TeacherByCourse> TeachersByCourse { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Guardian> Guardians { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            // InfrastructureReport
            modelBuilder.Entity<InfrastructureReport>()
                .HasKey(ir => ir.IdInfrastructureReport);

            modelBuilder.Entity<InfrastructureReport>()
                .HasOne(ir => ir.Teacher)
                .WithMany(t => t.InfrastructureReports)
                .HasForeignKey(ir => ir.TeacherId);

            // Inventory
            modelBuilder.Entity<Inventory>()
                .HasKey(i => i.IdInventory);

            // Administrator
            modelBuilder.Entity<Administrator>()
                .HasKey(a => a.IdAdministrator);

            // InventoryRequest
            modelBuilder.Entity<InventoryRequest>()
                .HasKey(ir => new { ir.DateTime, ir.InventoryId, ir.TeacherId, ir.AdministratorId });

            modelBuilder.Entity<InventoryRequest>()
                .HasOne(ir => ir.Inventory)
                .WithMany(i => i.InventoryRequests)
                .HasForeignKey(ir => ir.InventoryId);

            modelBuilder.Entity<InventoryRequest>()
                .HasOne(ir => ir.Teacher)
                .WithMany(t => t.InventoryRequests)
                .HasForeignKey(ir => ir.TeacherId);

            modelBuilder.Entity<InventoryRequest>()
                .HasOne(ir => ir.Administrator)
                .WithMany(a => a.InventoryRequests)
                .HasForeignKey(ir => ir.AdministratorId);

            // TeacherByCourse
            modelBuilder.Entity<TeacherByCourse>()
                .HasKey(tc => new { tc.CourseId, tc.SectionId, tc.TeacherId });

            modelBuilder.Entity<TeacherByCourse>()
                .HasOne(tc => tc.Teacher)
                .WithMany(t => t.TeachersByCourse)
                .HasForeignKey(tc => tc.TeacherId);

            modelBuilder.Entity<TeacherByCourse>()
                .HasOne(tc => tc.Course)
                .WithMany(c => c.TeacherByCourses)
                .HasForeignKey(tc => new { tc.CourseId, tc.SectionId });
        }
}