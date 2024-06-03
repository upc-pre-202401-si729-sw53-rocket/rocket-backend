namespace ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TeacherByCourse
{
    [Key]
    public int IdTeacherByCourse { get; set; }
    public int CourseId { get; set; }
    public int SectionId { get; set; }
    public int TeacherId { get; set; }

    [ForeignKey("CourseId")]
    public Course Course { get; set; }
    [ForeignKey("SectionId")]
    public Teacher Teacher { get; set; }
}