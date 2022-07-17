using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Services
{
    public class CustomerService
    {
        private CustomerContext _context;

        public CustomerService(CustomerContext context)
        {
            _context = context;
        }

        public Customer AddCustomer(CustomerViewModel model)
        {
            var customer = _context.Customers.Add(new Customer(null, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber ));
            _context.SaveChanges();

            return customer.Entity;
        }

        public List<Customer> GetAllCustomers()
        {
            var query = from b in _context.Customers
                        orderby b.Lastname
                        select b;

            return query.ToList();
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var query = from b in _context.Customers
                        orderby b.Lastname
                        select b;

            return await query.ToListAsync();
        }

        public void DeleteCustomer(string id)
        {
            _context.Remove(id);
        }
    }
}
