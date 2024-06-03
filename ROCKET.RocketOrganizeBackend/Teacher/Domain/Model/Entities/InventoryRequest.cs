namespace ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class InventoryRequest
{
    [Key]
    public int Id { get; set; }
    public DateTime DateTime { get; set; }

    [ForeignKey("Inventory")]
    public int InventoryId { get; set; }
    public Inventory Inventory { get; set; }

    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }

    [ForeignKey("Administrator")]
    public int AdministratorId { get; set; }
    public Administrator Administrator { get; set; }
}