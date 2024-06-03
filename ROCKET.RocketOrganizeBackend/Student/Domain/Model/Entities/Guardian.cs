namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Guardian
{
    [Key]
    public int IdGuardian { get; set; }
    public string FirstName { get; set; }
    public string PaternalSurname { get; set; }
    public string MaternalSurname { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public List<StudentByGuardian> StudentByGuardians { get; set; }
}