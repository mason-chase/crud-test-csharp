using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mc2.CrudTest.Presentation.Server.Context;
using Mc2.CrudTest.Presentation.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Domain.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context; 
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Customer> Queryable()
        {
            return _context.Customers.AsQueryable();
        }

        public async Task<List<Customer>> GetList()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> FilterGet(Expression<Func<Customer, bool>> expression)
        {
            return await _context.Customers.FirstOrDefaultAsync(expression);
        }

        public async Task<Customer> AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            return customer;
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public async Task<bool> Delete(int id)
        {
            Customer customer = await FilterGet(x=>x.Id == id);
            if (customer is null)
                return false;
            _context.Customers.Remove(customer);
            return true;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
