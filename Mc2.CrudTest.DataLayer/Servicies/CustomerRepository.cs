using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.DataLayer.Common;
using Mc2.CrudTest.DataLayer.Context;
using Mc2.CrudTest.DataLayer.Entities;
using Mc2.CrudTest.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using PhoneNumbers;

namespace Mc2.CrudTest.DataLayer.Servicies
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public Task<Customer> GetCustomerByEmail(string customerEmail)
        {
            return _context.Customers
                .SingleOrDefaultAsync(c => c.Email == customerEmail);
        }

        public async Task<bool> AddCustomer(Customer customer)
        {
            PhoneValidation phoneValidation = new();
            var result = phoneValidation.PhoneIsValid(customer.PhoneNumber);
            if (!result)
            {
                return false;
            }
            try
            {
                customer.Email = customer.Email.ToLower();
                await _context.Customers.AddAsync(customer);
                await Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            PhoneValidation phoneValidation = new();
            var result = phoneValidation.PhoneIsValid(customer.PhoneNumber);
            if (!result)
            {
                return false;
            }
            try
            {
                customer.Email = customer.Email.ToLower();
                _context.Customers.Update(customer);
                await Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCustomer(Customer customer)
        {
            try
            {
                _context.Customers.Remove(customer);
                await Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteCustomer(string customerEmail)
        {
            var customer = await GetCustomerByEmail(customerEmail);
            var result = await DeleteCustomer(customer);
            if (!result)
            {
                return false;
            }

            return true;
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
