using System.Linq.Expressions;
using CleanArchitecture.Domain.Context;
using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Repositories;

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
        Customer customer = await FilterGet(x => x.Id == id);
        if (customer is null)
            return false;
        _context.Customers.Remove(customer);
        return true;
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<Customer> GetById(int id) => await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
}
