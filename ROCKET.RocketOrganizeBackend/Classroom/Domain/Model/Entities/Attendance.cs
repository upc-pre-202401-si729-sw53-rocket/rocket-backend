namespace ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("attendances")]
public class Attendance
{
    [Key]
    public int IdAttendance { get; set; }
    public DateTime Date { get; set; }
    public int CourseId { get; set; }
    public int SectionId { get; set; }
}