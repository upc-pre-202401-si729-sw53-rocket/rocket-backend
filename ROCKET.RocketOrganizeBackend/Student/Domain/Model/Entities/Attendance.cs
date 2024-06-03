namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Attendance
{
    [Key]
    public int IdAttendance { get; set; }
    public DateTime Date { get; set; }
    public int CourseId { get; set; }
    public int SectionId { get; set; }
    
    [ForeignKey("CourseId, SectionId")]
    public Course Course { get; set; }
    public List<StudentsByAttendance> StudentsByAttendances { get; set; }
}