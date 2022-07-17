using Domain;
using Domain.AggregatesModel.CustomerAggregate;
using Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{

    public class CustomerRepository
        : ICustomerRepository
    {
        private readonly CustomerContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public CustomerRepository(CustomerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers; ;
        }

        public Customer Add(Customer customer)
        {
            if (customer.IsTransient())
            {
                return _context.Customers
                    .Add(customer)
                    .Entity;
            }
            else
            {
                return customer;
            }
        }

        public Customer Update(Customer customer)
        {
            return _context.Customers
                    .Update(customer)
                    .Entity;
        }

        public void Delete(int id)
        {

            var cs = _context.Customers.Where(c => c.Id == id).FirstOrDefault();
            _context.Customers.Remove(cs);

        }

        public async Task<Customer> FindAsync(string identity)
        {
            var customer = await _context.Customers
                .Where(b => b.IdentityGuid == identity)
                .SingleOrDefaultAsync();

            return customer;
        }

        public async Task<Customer> FindByIdAsync(string id)
        {
            var customer = await _context.Customers
                .Where(b => b.Id == int.Parse(id))
                .SingleOrDefaultAsync();

            return customer;
        }
    }

}