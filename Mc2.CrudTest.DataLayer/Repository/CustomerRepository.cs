using Mc2.CrudTest.DataLayer.Context;
using Mc2.CrudTest.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.DataLayer.Repository
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public void DeleteEntity(Customer entity)
        {
            entity.IsDelete = true;
            EditEntity(entity);
        }

        IQueryable<Customer> ICustomerRepository.GetQuery()
        {
            return _context.Customers.AsQueryable();
        }

        public async Task AddEntity(Customer entity)
        {
            await _context.Customers.AddAsync(entity);
        }

        public async Task<Customer> GetEntity(string firstName, string lastName, DateTime dateOfBirth)
        {
            return await _context.Customers.SingleOrDefaultAsync(s => s.FirstName == firstName && s.LastName == lastName && s.DateOfBirth == dateOfBirth);
        }

        public void EditEntity(Customer entity)
        {
            _context.Customers.Update(entity);
        }

        public async Task DeleteEntity(string firstName, string lastName, DateTime dateOfBirth)
        {
            Customer entity = await GetEntity(firstName, lastName, dateOfBirth);
            if (entity != null) DeleteEntity(entity);
        }

        public void DeletePermanent(Customer entity)
        {
            _context.Customers.Remove(entity);
        }

        public async Task DeletePermanent(string firstName, string lastName, DateTime dateOfBirth)
        {
            Customer entity = await GetEntity(firstName, lastName, dateOfBirth);
            if (entity != null) DeletePermanent(entity);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
