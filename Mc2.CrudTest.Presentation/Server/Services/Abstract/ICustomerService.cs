using Domain;
using System.Collections.Generic;

namespace Mc2.CrudTest.Presentation.Server.Services.Abstract
{
    public interface ICustomerService
    {
        Customer AddCustomer(Customer model);


        List<Customer> GetAllCustomers();


        void DeleteCustomer(int id);

    }
}
