using Mc2.CrudTest.DataAccess;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Commands;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.CommandHandlers
{


    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly DataContext _dataContext;
        public UpdateCustomerCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _dataContext.Customers.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (customer is null) return null;
            var customerUpdate = Customer.UpdateCustomer(request.Id, request.Firstname, request.Lastname, request.DateOfBirth, request.PhoneNumber, request.Email, request.BankAccountNumber);
            _dataContext.Customers.Update(customerUpdate);
            await _dataContext.SaveChangesAsync();
            return customerUpdate;
        }
    }
}
