namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("studentsbyattendance")]
public class StudentsByAttendance
{
    [Key]
    public int Id { get; set; }
    public int State { get; set; }

    [ForeignKey("Attendance")]
    public int AttendanceId { get; set; }
    public Attendance Attendance { get; set; }

    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public Student Student { get; set; }
}