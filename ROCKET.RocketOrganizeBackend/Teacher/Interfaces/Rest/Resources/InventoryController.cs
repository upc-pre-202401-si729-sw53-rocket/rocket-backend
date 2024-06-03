namespace ROCKET.RocketOrganizeBackend.Teacher.Interfaces.Rest.Resources;
using ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class InventoryController : ControllerBase
{
    private readonly InventoryQueryService queryService;
    private readonly InventoryCommandService commandService;

    public InventoryController(InventoryQueryService queryService, InventoryCommandService commandService)
    {
        this.queryService = queryService;
        this.commandService = commandService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Inventory>>> GetInvetories()
    {
        var inventories = await queryService.GetAllInventoriesAsync();
        return Ok(inventories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Inventory>> GetInventory(int id)
    {
        var inventory = await queryService.GetInventoryByIdAsync(id);
        if (inventory == null)
        {
            return NotFound();
        }
        return Ok(inventory);
    }

    [HttpPost]
    public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
    {
        await commandService.AddInventoryAsync(inventory);
        return CreatedAtAction(nameof(GetInventory), new { id = inventory.IdInventory }, inventory);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutInventory(int id, Inventory inventory)
    {
        if (id != inventory.IdInventory)
        {
            return BadRequest();
        }
        await commandService.UpdateInventoryAsync(inventory);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInventory(int id)
    {
        await commandService.DeleteInventoryAsync(id);
        return NoContent();
    }
}