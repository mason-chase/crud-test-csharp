using c2.CrudTest.Application.Commands;
using Mc2.CrudTest.Domain.Models.Entities;
using Mc2.CrudTest.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace c2.CrudTest.Application.CommandHandler
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerEntity>
    {
        private readonly CustomerDbContext _customerDbContext;
        public UpdateCustomerCommandHandler(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        public async Task<CustomerEntity> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = _customerDbContext.Customers.Where(a => a.Id == command.Id).FirstOrDefault();
            if (customer == null)
            {
                return default;
            }
            else
            {
                customer.FirstName = command.FirstName;
                customer.LastName = command.LastName;
                customer.DateOfBirth = command.DateOfBirth;
                customer.PhoneNumber = command.PhoneNumber;
                customer.Email = command.Email;
                customer.BankAccountNumber = command.BankAccountNumber;

                await _customerDbContext.SaveChangesAsync();
                return customer;
            }
        }
    }
}