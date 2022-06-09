using Mc2.CrudTest.DataAccess;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Commands;

namespace Mc2.CrudTest.Application.Customers.CommandHandlers
{


    public class UpdateCustomerCommandHandler
    {
        private readonly DataContext _dataContext;
        public UpdateCustomerCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request)
        {
            var customer = await _dataContext.Customers.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (customer is null) return null;
            var customerUpdate = Customer.CreateCustomer(request.Id, request.Firstname, request.Lastname, request.DateOfBirth, request.PhoneNumber, request.Email, request.BankAccountNumber);
            customer.UpdateCustomer(customerUpdate);
            _dataContext.Customers.Update(customer);
            await _dataContext.SaveChangesAsync();
            return customer;
        }
    }
}
