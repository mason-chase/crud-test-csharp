﻿using Mc2.CrudTest.Customers.Dtos;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Customers
{
    public interface ICustomerService
    {
        Task<GetCustomersOutput> GetCustomers(GetCustomersInput model);
        Task<GetCustomerOutput> GetCustomer(GetCustomerInput model);
        Task<DeleteCustomerOutput> DeleteCustomer(DeleteCustomerInput model);
        Task<UpsertCustomerOutput> UpsertCustomer(UpsertCustomerInput model);
    }
}
