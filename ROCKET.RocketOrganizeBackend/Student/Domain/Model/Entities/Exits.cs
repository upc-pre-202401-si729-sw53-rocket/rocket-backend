namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("exits")]
public class Exits
{
    [Key]
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public string Reason { get; set; }

    [ForeignKey("Student")]
    public int StudentId { get; set; }
    public Student Student { get; set; }
}