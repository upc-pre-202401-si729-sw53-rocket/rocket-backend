namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("guardian")]
public class Guardian
{
    [Key]
    public int IdGuardian { get; set; }
    public string FirstName { get; set; }
    public string PaternalSurname { get; set; }
    public string MaternalSurname { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public ICollection<StudentByGuardian> StudentsByGuardians { get; set; }
}