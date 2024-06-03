namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class StudentsByAttendance
{
    [Key]
    public int IdStudentsByAttendance { get; set; }
    public int AttendanceId { get; set; }
    public int StudentId { get; set; }
    
    [ForeignKey("AttendanceId")]
    public Attendance Attendance { get; set; }
    [ForeignKey("StudentId")]
    public Student Student { get; set; }
}