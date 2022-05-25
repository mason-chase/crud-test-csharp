using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        //Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(IEnumerable<T> entities);
        Task<bool> Remove(T entity);
        Task<bool> RemoveRange(IEnumerable<T> entities);
        Task<T> FirstOrDefaultAsync(Expression<Func<T,bool>> expression);
        Task<bool> UpdateAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
}
