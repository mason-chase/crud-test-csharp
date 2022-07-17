namespace Mc2.CrudTest.Presentation.Server.Queries
{
    using global::Domain;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICustomerQueries
    {
        Task<Customer> GetCustomerAsync(int id);


    }
}
}
