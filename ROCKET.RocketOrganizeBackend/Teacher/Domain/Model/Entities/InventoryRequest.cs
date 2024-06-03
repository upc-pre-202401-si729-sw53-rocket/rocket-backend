namespace ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class InventoryRequest
{
    [Key]
    public DateTime DateTime { get; set; }
    public int InventoryId { get; set; }
    public int TeacherId { get; set; }
    public int AdministratorId { get; set; }
    [ForeignKey("InventoryId")]
    public Inventory Inventory { get; set; }
    [ForeignKey("TeacherId")]
    public Teacher Teacher { get; set; }
    [ForeignKey("AdministratorId")]
    public Administrator Administrator { get; set; }
}