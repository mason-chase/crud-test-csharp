using Mc2.CrudTest.Customers;
using System;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Common
{
    public interface IUnitOfWork :IDisposable
    {
        ICustomerRepository Customers { get; }
        Task<int> CompleteAsync();
    }
}
