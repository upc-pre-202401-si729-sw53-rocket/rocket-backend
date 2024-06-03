namespace ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Student.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Exits
{
    [Key]
    public DateTime IdExit { get; set; }
    public DateTime DateTime { get; set; }
    public string Reason { get; set; }
    public int StudentId { get; set; }
    public List<Student> Students { get; set; }
    [ForeignKey("StudentId")]
    public Student Student { get; set; }
}