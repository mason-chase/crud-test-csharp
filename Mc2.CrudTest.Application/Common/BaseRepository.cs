using Mc2.CrudTest.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly MC2Context _context;

        public BaseRepository(MC2Context context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<T> AddAndGetAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).AnyAsync();
        }

        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).Any();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetByStoredProcedure(string name, List<SqlParameter> parameters, int? timeout = 30)
        {
            foreach (var item in parameters)
            {
                if (item.Direction == ParameterDirection.Output)
                    name += " @" + item.ParameterName + " out,";
                else
                    name += " @" + item.ParameterName + ",";
            }

            name = name.Substring(0, name.Length - 1);

            _context.Database.SetCommandTimeout(timeout);

            var res = await _context.Set<T>().FromSqlRaw(name, parameters.ToArray()).AsNoTracking().ToListAsync();

            return res;
        }

        public async Task<int> CallStoredProcedure(string name, List<SqlParameter> parameters, int? timeout = 30)
        {
            foreach (var item in parameters)
            {
                if (item.Direction == ParameterDirection.Output)
                    name += " @" + item.ParameterName + " out,";
                else
                    name += " @" + item.ParameterName + ",";
            }

            name = name.Substring(0, name.Length - 1);

            _context.Database.SetCommandTimeout(timeout);

            var res = await _context.Database.ExecuteSqlRawAsync(name, parameters.ToArray());

            return res;
        }

        
    }
}
