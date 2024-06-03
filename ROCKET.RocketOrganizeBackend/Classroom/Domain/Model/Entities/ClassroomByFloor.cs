namespace ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ClassroomByFloor
{
    [Key]
    [Column(Order = 0)]
    public int FloorId { get; set; }
    [Key]
    [Column(Order = 1)]
    public int ClassroomId { get; set; }
    public Floor Floor { get; set; }
    public Classroom Classroom { get; set; }
}