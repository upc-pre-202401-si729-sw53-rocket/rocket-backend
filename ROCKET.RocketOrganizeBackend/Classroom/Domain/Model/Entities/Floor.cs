namespace ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Floor
{
    [Key]
    public int IdFloor { get; set; }
    [ForeignKey("Pavilion")]
    public int PavilionsIdPavilion { get; set; }
    public Pavilion Pavilion { get; set; }
}