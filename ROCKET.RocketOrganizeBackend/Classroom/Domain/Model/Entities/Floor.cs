namespace ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Floor
{
    [Key]
    public int IdFloor { get; set; }
    public int PavilionId { get; set; }
    [ForeignKey("PavilionId")]
    public Pavilion Pavilion { get; set; }
    public List<ClassroomByFloor> ClassroomsByFloor { get; set; }
}