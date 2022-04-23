using Mc2.CrudTest.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.DataLayer.Repository
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetQuery();
        Task AddEntity(Customer entity);
        Task<Customer> GetEntity(string firstName, string lastName, DateTime dateOfBirth);
        void EditEntity(Customer entity);
        Task DeleteEntity(string firstName, string lastName, DateTime dateOfBirth);
        Task DeletePermanent(string firstName, string lastName, DateTime dateOfBirth);
        Task SaveChanges();
    }

}
