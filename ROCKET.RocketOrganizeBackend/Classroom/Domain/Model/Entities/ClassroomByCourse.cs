namespace ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ClassroomByCourse
{
    [Key]
    [Column(Order = 0)]
    public int ClassroomId { get; set; }
    [Key]
    [Column(Order = 1)]
    public int CourseId { get; set; }
    [Key]
    [Column(Order = 2)]
    public int SectionId { get; set; }
    public Classroom Classroom { get; set; }
    public Course Course { get; set; }
}