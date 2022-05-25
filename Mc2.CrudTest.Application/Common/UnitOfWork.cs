using Mc2.CrudTest.Context;
using Mc2.CrudTest.Customers;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly MC2Context _context;
        
        public UnitOfWork(MC2Context context)
        {
            _context = context;
            Customers = new CustomerRepository(_context);
        }

        public ICustomerRepository Customers { get; private set; }
        
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}