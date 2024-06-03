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
    public DbSet<StudentsByGrade> StudentsByGrades { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Attendance
            modelBuilder.Entity<Attendance>()
                .HasKey(a => a.IdAttendance);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Course)
                .WithMany(c => c.Attendances)
                .HasForeignKey(a => new { a.CourseId, a.SectionId });

            // Exits
            modelBuilder.Entity<Exits>()
                .HasKey(e => e.IdExit);

            modelBuilder.Entity<Exits>()
                .HasOne(e => e.Students)
                // .WithMany(s => s.Exits)
                .WithMany()
                .HasForeignKey(e => e.StudentId);

            // Grade
            modelBuilder.Entity<Grade>()
                .HasKey(g => g.IdGrade);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Course)
                .WithMany(c => c.Grades)
                .HasForeignKey(g => new { g.CourseId, g.SectionId });

            // Guardian
            modelBuilder.Entity<Guardian>()
                .HasKey(g => g.IdGuardian);

            // RegistrationStatus
            modelBuilder.Entity<RegistrationStatus>()
                .HasKey(rs => rs.IdRegistrationStatus);

            // StudentByGuardian
            modelBuilder.Entity<StudentByGuardian>()
                .HasKey(sb => new { sb.StudentId, sb.GuardianId });

            modelBuilder.Entity<StudentByGuardian>()
                .HasOne(sg => sg.Student)
                .WithMany(s => s.StudentByGuardians)
                .HasForeignKey(sg => sg.StudentId);

            modelBuilder.Entity<StudentByGuardian>()
                .HasOne(sg => sg.Guardian)
                .WithMany(g => g.StudentByGuardians)
                .HasForeignKey(sg => sg.GuardianId);

            // Student
            modelBuilder.Entity<Student>()
                .HasKey(s => s.IdStudent);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.RegistrationStatus)
                .WithMany(rs => rs.Students)
                .HasForeignKey(s => s.RegistrationStatusId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Exits)
                .WithOne(e => e.Student)
                .HasForeignKey<Exits>(e => e.StudentId);

            // StudentsByAttendance
            modelBuilder.Entity<StudentsByAttendance>()
                .HasKey(sa => new { sa.AttendanceId, sa.StudentId });

            modelBuilder.Entity<StudentsByAttendance>()
                .HasOne(sa => sa.Attendance)
                .WithMany(a => a.StudentsByAttendances)
                .HasForeignKey(sa => sa.AttendanceId);

            modelBuilder.Entity<StudentsByAttendance>()
                .HasOne(sa => sa.Student)
                .WithMany(s => s.StudentsByAttendances)
                .HasForeignKey(sa => sa.StudentId);

            // StudentsByGrade
            modelBuilder.Entity<StudentsByGrade>()
                .HasKey(sg => new { sg.GradeId, sg.StudentId });

            modelBuilder.Entity<StudentsByGrade>()
                .HasOne(sg => sg.Grade)
                .WithMany(g => g.StudentsByGrades)
                .HasForeignKey(sg => sg.GradeId);

            modelBuilder.Entity<StudentsByGrade>()
                .HasOne(sg => sg.Student)
                .WithMany(s => s.StudentsByGrades)
                .HasForeignKey(sg => sg.StudentId);
        }
}