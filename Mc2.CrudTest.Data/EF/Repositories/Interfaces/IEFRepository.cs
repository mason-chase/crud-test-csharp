using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Data.EF.Repositories.Interfaces;

public interface IEFRepository<T> where T : class
{
    DbSet<T> Entities { get; }
    IQueryable<T> Table { get; }
    IQueryable<T> TableNoTracking { get; }

    ValueTask<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    ValueTask<T> GetByIdAsync(CancellationToken cancellationToken, params object[] ids);
    ValueTask AddAsync(T entity, CancellationToken cancellationToken, bool saveNow = true);
    ValueTask AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken, bool saveNow = true);
    ValueTask DeleteAsync(T entity, CancellationToken cancellationToken, bool saveNow = true);
    ValueTask DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken, bool saveNow = true);
    ValueTask UpdateAsync(T entity, CancellationToken cancellationToken, bool saveNow = true);
    ValueTask UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken, bool saveNow = true);
}