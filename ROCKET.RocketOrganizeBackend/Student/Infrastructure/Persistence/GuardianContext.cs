namespace ROCKET.RocketOrganizeBackend.Student.Infrastructure.Persistence;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

public class GuardianContext : DbContext
{
    public GuardianContext(DbContextOptions<GuardianContext> options) : base(options) { }
    
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Exits> Exits { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Guardian> Guardians { get; set; }
    public DbSet<RegistrationStatus> RegistrationStatuses { get; set; }
    public DbSet<StudentByGuardian> StudentsByGuardians { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentsByAttendance> StudentsByAttendances { get; set; }
    public DbSet<StudentByGrade> StudentsByGrades { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Student)
            .WithOne(s => s.Attendances); 
            // .HasForeignKey(a => a.StudentId);
        
        modelBuilder.Entity<Exits>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Exits)
            .HasForeignKey(e => e.StudentId);

        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Student)
            .WithOne(s => s.Grades);
            //.HasForeignKey(g => g.StudentId);
        
        modelBuilder.Entity<Guardian>()
            .HasMany(g => g.StudentsByGuardians)
            .WithOne(sb => sb.Guardian)
            .HasForeignKey(sb => sb.GuardianId);
        
        modelBuilder.Entity<RegistrationStatus>()
            .HasMany(rs => rs.Students)
            .WithOne(s => s.RegistrationStatus)
            .HasForeignKey(s => s.RegistrationStatusId);
        
        modelBuilder.Entity<StudentsByAttendance>()
            .HasKey(sa => new { sa.StudentId, sa.AttendanceId });

        modelBuilder.Entity<StudentByGuardian>()
            .HasKey(sb => new { sb.StudentId, sb.GuardianId });

        modelBuilder.Entity<StudentByGuardian>()
            .HasOne(sb => sb.Student)
            .WithMany(s => s.StudentsByGuardians)
            .HasForeignKey(sb => sb.StudentId);

        modelBuilder.Entity<StudentByGuardian>()
            .HasOne(sb => sb.Guardian)
            .WithMany(g => g.StudentsByGuardians)
            .HasForeignKey(sb => sb.GuardianId);

        modelBuilder.Entity<StudentByGrade>()
            .HasKey(sg => new { sg.StudentId, sg.GradeId });
        
        modelBuilder.Entity<StudentByGrade>()
            .HasOne(sg => sg.Student)
            .WithMany(s => s.StudentsByGrades)
            .HasForeignKey(sg => sg.StudentId);
        
        modelBuilder.Entity<StudentByGrade>()
            .HasOne(sg => sg.Grade)
            .WithMany(g => g.StudentsByGrades)
            .HasForeignKey(sg => sg.GradeId);
    }
}