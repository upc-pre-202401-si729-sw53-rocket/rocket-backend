namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Grade
{
    [Key]
    public int IdGrade { get; set; }
    public string Name { get; set; }
    public int CourseId { get; set; }
    public int SectionId { get; set; }

    [ForeignKey("CourseId, SectionId")]
    public Course Course { get; set; }
    public List<StudentsByGrade> StudentsByGrades { get; set; }
}