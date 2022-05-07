using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mc2.CrudTest.Presentation.Server.Models;

namespace Mc2.CrudTest.Domain.Repositories
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Queryable();
        Task<List<Customer>> GetList();
        Task<Customer> FilterGet(Expression<Func<Customer, bool>> expression);
        Task<Customer> AddAsync(Customer customer);
        void Update(Customer customer);
        Task<bool> Delete(int id);
        Task SaveChanges();
    }
}
