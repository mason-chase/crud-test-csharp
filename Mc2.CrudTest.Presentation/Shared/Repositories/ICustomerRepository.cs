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
        /// <summary>
        ///     Get Queryable 
        /// </summary>
        /// <returns></returns>
        IQueryable<Customer> Queryable();
        /// <summary>
        ///  Get List Of Customers
        /// </summary>
        /// <returns></returns>
        Task<List<Customer>> GetList();
        /// <summary>
        ///  Get By Id Or Get Specific Customer By Expression
        /// </summary>
        /// <param name="expression"> Example  => (x => x.Id == Id) </param>
        /// <returns></returns>
        Task<Customer> FilterGet(Expression<Func<Customer, bool>> expression);
        /// <summary>
        ///     Add Async the Customer To The Database
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task<Customer> AddAsync(Customer customer);
        /// <summary>
        ///  Update Customer
        /// </summary>
        /// <param name="customer"></param>
        void Update(Customer customer);
        // Delete Customer By Id
        Task<bool> Delete(int id);
        /// <summary>
        ///  Save Changes 
        /// </summary>
        /// <returns></returns>
        Task SaveChanges();
    }
}
