namespace ROCKET.RocketOrganizeBackend.Classroom.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Pavilion
{
    [Key]
    public int IdPavilion { get; set; }
    public string Name { get; set; }
}