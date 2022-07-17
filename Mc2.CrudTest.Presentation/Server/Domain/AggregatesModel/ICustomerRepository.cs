using Domain.Seedwork;
using System.Threading.Tasks;

namespace Domain.AggregatesModel.CustomerAggregate
{

    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer Add(Customer customer);
        Customer Update(Customer customer);

        void Delete(int id);
        Task<Customer> FindAsync(string customerIdentityGuid);
        Task<Customer> FindByIdAsync(string id);
    }

}
