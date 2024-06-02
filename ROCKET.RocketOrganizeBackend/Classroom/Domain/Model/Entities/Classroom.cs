namespace ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Classroom
{
    [Key]
    public int IdClassroom { get; set; }
    public int Capacity { get; set; }
    public int Slots { get; set; }
}