using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Interfaces;

namespace Mc2.CrudTest.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context) { }
    }
}
