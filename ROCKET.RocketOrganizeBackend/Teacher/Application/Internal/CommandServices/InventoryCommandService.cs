namespace ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.QueryServices;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using System.Threading.Tasks;

public class InventoryCommandService
{
    private readonly InventoryRepository repository;

    public InventoryCommandService(InventoryRepository repository)
    {
        this.repository = repository;
    }

    public async Task AddInventoryAsync(Inventory inventory)
    {
        await repository.AddInventoryAsync(inventory);
    }

    public async Task UpdateInventoryAsync(Inventory inventory)
    {
        await repository.UpdateInventoryAsync(inventory);
    }

    public async Task DeleteInventoryAsync(int inventoryId)
    {
        await repository.DeleteInventoryAsync(inventoryId);
    }
}