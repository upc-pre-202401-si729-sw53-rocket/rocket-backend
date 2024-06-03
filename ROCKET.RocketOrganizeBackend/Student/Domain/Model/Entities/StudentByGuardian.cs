using System.ComponentModel.DataAnnotations;

namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

public class StudentByGuardian
{
    [Key]
    public int IdStudentByGuardian { get; set; }
    public int StudentId { get; set; }
    public int GuardianId { get; set; }

    [ForeignKey("StudentId")]
    public Student Student { get; set; }

    [ForeignKey("GuardianId")]
    public Guardian Guardian { get; set; }
}