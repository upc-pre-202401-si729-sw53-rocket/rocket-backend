namespace ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ClassroomByCourse
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Classroom")]
    public int ClassroomsIdClassroom { get; set; }

    [ForeignKey("Course")]
    public int CoursesIdCourse { get; set; }

    public int CoursesIdSection { get; set; }

    public Classroom Classroom { get; set; }
    public Course Course { get; set; }
}