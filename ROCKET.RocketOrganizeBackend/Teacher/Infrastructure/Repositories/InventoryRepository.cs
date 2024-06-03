namespace ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class InventoryRepository
{
    private readonly InventoryContext _context;

    public InventoryRepository(InventoryContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Inventory>> GetAllInventoriesAsync()
    {
        return await _context.Inventories.ToListAsync();
    }

    public async Task<Inventory> GetInventoryByIdAsync(int inventoryId)
    {
        return await _context.Inventories.FindAsync(inventoryId);
    }

    public async Task AddInventoryAsync(Inventory inventory)
    {
        _context.Inventories.Add(inventory);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateInventoryAsync(Inventory inventory)
    {
        _context.Inventories.Update(inventory);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteInventoryAsync(int inventoryId)
    {
        var inventory = await _context.Inventories.FindAsync(inventoryId);
        if (inventory != null)
        {
            _context.Inventories.Remove(inventory);
            await _context.SaveChangesAsync();
        }
    }
}