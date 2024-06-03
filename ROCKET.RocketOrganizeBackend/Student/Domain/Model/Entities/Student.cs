namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student
{
    [Key]
    public int IdStudent { get; set; }
    public string FirstName { get; set; }
    public string PaternalSurname { get; set; }
    public string MaternalSurname { get; set; }
    public string Email { get; set; }
    public int RegistrationStatusId { get; set; }

    [ForeignKey("RegistrationStatusId")]
    public RegistrationStatus RegistrationStatus { get; set; }
    public List<StudentByGuardian> StudentByGuardians { get; set; }
    
    [NotMapped]
    public Exits Exits { get; set; }
    public List<StudentsByAttendance> StudentsByAttendances { get; set; }
    public List<StudentsByGrade> StudentsByGrades { get; set; }
}