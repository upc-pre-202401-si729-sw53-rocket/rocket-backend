namespace ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ClassroomByFloor
{
    [Key]
    public int FloorsIdFloor { get; set; }
    [ForeignKey("Floor")]
    public int ClassroomsIdClassroom { get; set; }
    public Grade Grade { get; set; }
    public Classroom Classroom { get; set; }
}