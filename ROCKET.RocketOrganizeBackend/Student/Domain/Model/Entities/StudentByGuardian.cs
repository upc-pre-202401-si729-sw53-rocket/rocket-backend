namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("studentbyguardian")]
public class StudentByGuardian
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public Student Student { get; set; }

    [ForeignKey("Guardian")]
    public int GuardianId { get; set; }
    public Guardian Guardian { get; set; }
}