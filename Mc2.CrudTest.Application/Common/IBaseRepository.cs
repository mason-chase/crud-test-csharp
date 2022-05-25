using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Common
{
    public interface IBaseRepository<T> where T : class
    {
        bool Any(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task<T> AddAndGetAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<T> GetByIdAsync(Guid id);
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<List<T>> GetByStoredProcedure(string name, List<SqlParameter> parameters, int? timeout = 30);
        Task<int> CallStoredProcedure(string name, List<SqlParameter> parameters, int? timeout = 30);
    }
}
