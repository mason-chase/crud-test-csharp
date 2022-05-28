using Mc2.CrudTest.Data.EF.DatabaseContext;
using Mc2.CrudTest.Data.EF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Data.EF.Repositories.Concretes;

public class EFRepository<T> : IEFRepository<T> where T : class
{
    public EFRepository(AppDbContext context)
    {
        Context = context ?? throw new ArgumentNullException(nameof(context));
        Entities = context.Set<T>();
    }

    public DbSet<T> Entities { get; }
    protected readonly AppDbContext Context;

    public IQueryable<T> Table => Entities;
    public IQueryable<T> TableNoTracking => Entities.AsNoTracking();

    public async ValueTask<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await Entities.ToListAsync(cancellationToken);

        return result;
    }

    public async ValueTask<T> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
    {
        var result = await Entities.FindAsync(ids, cancellationToken);

        return result;
    }

    public async ValueTask AddAsync(T entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        ArgumentNullException.ThrowIfNull(entity);
  
        await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);
        if (saveNow)
            await Context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async ValueTask AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken, bool saveNow = true)
    {
        await Entities.AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
        if (saveNow)
            await Context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    public async ValueTask UpdateAsync(T entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        ArgumentNullException.ThrowIfNull(entity);
      
        Entities.Update(entity);
        if (saveNow)
            await Context.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask UpdateRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken, bool saveNow = true)
    {
        Entities.UpdateRange(entities);
        if (saveNow)
            await Context.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask DeleteAsync(T entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        ArgumentNullException.ThrowIfNull(entity);

        Entities.Remove(entity);
        if (saveNow)
            await Context.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask DeleteRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken, bool saveNow = true)
    {
        Entities.RemoveRange(entities);
        if (saveNow)
            await Context.SaveChangesAsync(cancellationToken);
    }
}