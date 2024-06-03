namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class StudentsByGrade
{
    [Key]
    public int IdStudentsByGrade { get; set; }
    public int StudentId { get; set; }
    public int GradeId { get; set; }
    public int ExamNote { get; set; }

    [ForeignKey("StudentId")]
    public Student Student { get; set; }
    [ForeignKey("GradeId")]
    public Grade Grade { get; set; }
}