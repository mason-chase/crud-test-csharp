using Mc2.CrudTest.Data.Contracts;
using Mc2.CrudTest.Queries.Contracts;
using Mc2.CrudTest.Queries.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Mc2.CrudTest.Queries.Queries
{
    public class GetCustomerListQuery : IGetCustomerListQuery
    {
        readonly IUnitOfWork _dataContext;
        public GetCustomerListQuery(IUnitOfWork dataContext)
        {
            _dataContext = dataContext;
        }

        public IList<CustomerViewModel> Execute()
        {
            return _dataContext.Customers
                       .Select(customer =>
                       new CustomerViewModel
                       {
                           Id = customer.Id,
                           FirstName = customer.Name.First,
                           LastName = customer.Name.Last,
                           DateOfBirth = customer.DateOfBirth,
                           BankAccountNumber = customer.BankAccountNumber.Value,
                           Email = customer.Email.Value,
                           CountryCode = customer.PhoneNumber.CountryCode,
                           PhoneNumber = customer.PhoneNumber.Number
                       }).AsNoTracking().ToList();
        }
    }
}
