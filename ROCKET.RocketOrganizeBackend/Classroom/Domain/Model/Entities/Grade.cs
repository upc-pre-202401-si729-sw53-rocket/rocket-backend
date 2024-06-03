using System.Text.Json.Serialization;

namespace ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("grades")]
public class Grade
{
    [Key]
    public int IdGrade { get; set; }
    public string Name { get; set; }
    public int CourseId { get; set; }
    public int SectionId { get; set; }
    
    [JsonIgnore]
    [ForeignKey("Pavilion")]
    public int PavilionsIdPavilion { get; set; }
    [JsonIgnore]    
    public Attendance Attendance { get; set; }
}