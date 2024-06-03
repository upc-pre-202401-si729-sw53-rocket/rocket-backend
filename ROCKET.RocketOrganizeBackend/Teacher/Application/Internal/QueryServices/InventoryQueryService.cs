namespace ROCKET.RocketOrganizeBackend.Teacher.Application.Internal.CommandServices;
using ROCKET.RocketOrganizeBackend.Teacher.Domain.Model.Entities;
using ROCKET.RocketOrganizeBackend.Teacher.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public class InventoryQueryService
{
    private readonly InventoryRepository repository;

    public InventoryQueryService(InventoryRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<Inventory>> GetAllInventoriesAsync()
    {
        return await repository.GetAllInventoriesAsync();
    }

    public async Task<Inventory> GetInventoryByIdAsync(int id)
    {
        return await repository.GetInventoryByIdAsync(id);
    }
}