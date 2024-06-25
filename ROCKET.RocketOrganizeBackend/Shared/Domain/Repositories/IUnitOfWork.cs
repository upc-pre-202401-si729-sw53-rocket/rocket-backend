namespace ROCKET.RocketOrganizeBackend.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}