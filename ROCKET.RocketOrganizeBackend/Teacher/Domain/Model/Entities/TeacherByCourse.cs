namespace ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TeacherByCourse
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("Course")]
    public int CourseId { get; set; }
    public int SectionId { get; set; }

    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }
    
    [InverseProperty("TeacherByCourse")]
    public Teacher Teacher { get; set; }
    
    [InverseProperty("TeacherByCourse")]
    public Course Course { get; set; }
}