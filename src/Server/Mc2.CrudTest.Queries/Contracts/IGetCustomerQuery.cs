using Mc2.CrudTest.Queries.ViewModel;
using System;

namespace Mc2.CrudTest.Queries.Contracts
{
    public interface IGetCustomerQuery : IQuery<CustomerViewModel>
    {
        CustomerViewModel Execute(Guid customerId);
    }
}
