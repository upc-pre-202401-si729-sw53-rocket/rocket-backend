namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("students")]
public class Student
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string PaternalSurname { get; set; }
    public string MaternalSurname { get; set; }
    public string Email { get; set; }

    [ForeignKey("RegistrationStatus")]
    public int RegistrationStatusId { get; set; }
    public RegistrationStatus RegistrationStatus { get; set; }

    public ICollection<StudentByGuardian> StudentsByGuardians { get; set; }
    public ICollection<StudentByGrade> StudentsByGrades { get; set; }
    public Attendance Attendances { get; set; }
    public Grade Grades { get; set; }
    public ICollection<Exits> Exits { get; set; }
}