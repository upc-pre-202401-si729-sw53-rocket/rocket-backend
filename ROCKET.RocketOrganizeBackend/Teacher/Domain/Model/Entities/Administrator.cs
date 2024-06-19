namespace ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

[Table("administrators")]
[Index(nameof(Email), IsUnique = true)]
public class Administrator
{
    [Key]
    public int IdAdministrator { get; set; }
    public string Name { get; set; }
    public string PaternalSurname { get; set; }
    public string MaternalSurname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}