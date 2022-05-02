using Mc2.CrudTest.Data.Contracts;
using Mc2.CrudTest.Queries.Contracts;
using Mc2.CrudTest.Queries.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Queries.Queries
{
    public class GetCustomerQuery : IGetCustomerQuery
    {
        readonly IUnitOfWork _dataContext;
        public GetCustomerQuery(IUnitOfWork dataContext)
        {
            _dataContext = dataContext;
        }

        public CustomerViewModel Execute(Guid customerId)
        {
            var customer = _dataContext.Customers
                .FirstOrDefault(_ => _.Id == customerId);

            if (customer == null) return new CustomerViewModel();

            return new CustomerViewModel
            {
                Id = customer.Id,
                FirstName = customer.Name.First,
                LastName = customer.Name.Last,
                DateOfBirth = customer.DateOfBirth,
                BankAccountNumber = customer.BankAccountNumber.Value,
                Email = customer.Email.Value,
                CountryCode = customer.PhoneNumber.CountryCode,
                PhoneNumber = customer.PhoneNumber.Number
            };
        }
    }
}
