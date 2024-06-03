using System.Text.Json.Serialization;

namespace ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Course
{
    [Key]
    public int IdCourse { get; set; }

    [ForeignKey("Section")]
    public int IdSection { get; set; }

    public string Name { get; set; }
    
    [JsonIgnore]
    public ICollection<TeacherByCourse> TeacherByCourse { get; set; } = new List<TeacherByCourse>();
}