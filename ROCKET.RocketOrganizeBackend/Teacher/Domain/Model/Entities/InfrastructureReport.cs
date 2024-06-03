using System.Text.Json.Serialization;

namespace ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("infrastructureReports")]
public class InfrastructureReport
{
    [Key]
    public int IdInfrastructureReport { get; set; }
    public string Description { get; set; }
    public DateTime DateTime { get; set; }

    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }
    
    [Required(AllowEmptyStrings = true)] 
    public Teacher Teacher { get; set; }
}