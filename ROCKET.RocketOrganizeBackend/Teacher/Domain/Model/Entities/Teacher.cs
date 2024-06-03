using System.Text.Json.Serialization;

namespace ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("teachers")]
public class Teacher
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string PaternalSurname { get; set; }
    public string MaternalSurname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    
    [JsonIgnore]
    public ICollection<InfrastructureReport> InfrastructureReport { get; set; } = new List<InfrastructureReport>();
    [JsonIgnore]
    public ICollection<InventoryRequest> InventoryRequest { get; set; } = new List<InventoryRequest>();
    [JsonIgnore]
    public ICollection<TeacherByCourse> TeacherByCourse { get; set; } = new List<TeacherByCourse>();
}