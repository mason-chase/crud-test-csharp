using Mc2.CrudTest.Queries.ViewModel;
using System.Collections.Generic;

namespace Mc2.CrudTest.Queries.Contracts
{
    public interface IGetCustomerListQuery : IQuery<IList<CustomerViewModel>>
    {
        IList<CustomerViewModel> Execute();
    }
}

