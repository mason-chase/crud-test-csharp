using Domain;
using Domain.Seedwork;
using System;
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

    public async Task<Customer> FindAsync(string identity)
    {
        var customer = await _context.Customers
            .Include(b => b.PaymentMethods)
            .Where(b => b.IdentityGuid == identity)
            .SingleOrDefaultAsync();

        return customer;
    }

    public async Task<Customer> FindByIdAsync(string id)
    {
        var customer = await _context.Customers
            .Include(b => b.PaymentMethods)
            .Where(b => b.Id == int.Parse(id))
            .SingleOrDefaultAsync();

        return customer;
    }
}

}