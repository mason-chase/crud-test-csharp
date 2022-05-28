namespace Mc2.CrudTest.Domain.SeedWork;

public interface IUnitOfWork
{
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}