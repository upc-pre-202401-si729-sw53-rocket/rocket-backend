namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("studentsbygrade")]
public class StudentByGrade
{
    [Key]
    public int Id { get; set; }
    public int ExamNote { get; set; }

    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public Student Student { get; set; }

    [ForeignKey("Grade")]
    public int GradeId { get; set; }
    public Grade Grade { get; set; }
}