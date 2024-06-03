namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class RegistrationStatus
{
    [Key]
    public int IdRegistrationStatus { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Student> Students { get; set; }
}