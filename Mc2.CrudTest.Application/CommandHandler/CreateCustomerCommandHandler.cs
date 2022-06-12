using c2.CrudTest.Application.Commands;
using Mc2.CrudTest.Domain.Models.Entities;
using Mc2.CrudTest.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace c2.CrudTest.Application.CommandHandler
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly CustomerDbContext _customerDbContext;
        public CreateCustomerCommandHandler(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        public async Task<bool> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new CustomerEntity();
            customer.FirstName = command.FirstName.ToLower();
            customer.LastName = command.LastName.ToLower();
            customer.DateOfBirth = command.DateOfBirth;
            customer.PhoneNumber = command.PhoneNumber;
            customer.Email = command.Email.ToLower();
            customer.BankAccountNumber = command.BankAccountNumber;

            _customerDbContext.Customers.Add(customer);
            await _customerDbContext.SaveChangesAsync();
            return true;
        }
    }
}