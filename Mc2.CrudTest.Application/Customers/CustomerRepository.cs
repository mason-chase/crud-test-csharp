using Mc2.CrudTest.Common;
using Mc2.CrudTest.Context;

namespace Mc2.CrudTest.Customers
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MC2Context context) : base(context)
        {

        }

    }
}
