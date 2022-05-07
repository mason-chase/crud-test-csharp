using System;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Presentation.Server.CQRS.Commands;
using Mc2.CrudTest.Presentation.Server.Models;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Queries
{
    public class AddCustomerHandler: IRequestHandler<AddCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _repository;
        public AddCustomerHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customerModel = new Customer()
            {
                Email = request.CustomerDto.Email, 
                Firstname = request.CustomerDto.Firstname,
                Lastname = request.CustomerDto.Lastname,
                PhoneNumber = request.CustomerDto.PhoneNumber,
                BankAccountNumber = request.CustomerDto.BankAccountNumber,
                DateOfBirth = request.CustomerDto.DateOfBirth
            };
            try
            {
                await _repository.AddAsync(customerModel);
                await _repository.SaveChanges();
            }
            catch (Exception e)
            {
                return null;
            }
           
            return customerModel;
        }
    }
}
