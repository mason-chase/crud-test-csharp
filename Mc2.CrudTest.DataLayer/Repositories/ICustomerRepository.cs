using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.DataLayer.Entities;

namespace Mc2.CrudTest.DataLayer.Repositories
{
    public interface ICustomerRepository : IAsyncDisposable
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomerByEmail(string customerEmail);
        Task<bool> AddCustomer(Customer customer);
        Task<bool> UpdateCustomer(Customer customer);
        Task<bool> DeleteCustomer(Customer customer);
        Task<bool> DeleteCustomer(string customerEmail);
        Task Save();
    }
}
