using System.Text.Json.Serialization;

namespace ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Teacher
{
    [Key]
    public int IdTeacher { get; set; }
    public string Name { get; set; }
    public string PaternalSurname { get; set; }
    public string MaternalSurname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public List<InfrastructureReport> InfrastructureReports { get; set; }
    public List<InventoryRequest> InventoryRequests { get; set; }
    public List<TeacherByCourse> TeachersByCourse { get; set; }
}