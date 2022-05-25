using Mc2.CrudTest.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataContext _context;
        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(T entity)
        {
            var res = await _context.Set<T>().AddAsync(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);

            return entities.All(i => _context.Entry(i).State == EntityState.Added);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> Remove(T entity)
        {
            var res = _context.Set<T>().Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(expression);
        }
        public async Task<bool> UpdateAsync(T entity)
        {
            _context.Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }
    }
}
