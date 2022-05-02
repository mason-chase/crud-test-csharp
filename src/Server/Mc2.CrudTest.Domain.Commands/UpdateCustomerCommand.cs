using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Repositories;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.Domain.Model.Exceptions;
using Mc2.CrudTest.Domain.Model.ValueObject;
using System;

namespace Mc2.CrudTest.Domain.Commands
{
    public class UpdateCustomerCommand : IUpdateCustomerCommand
    {
        private readonly ICustomerRepository _repository;
        public UpdateCustomerCommand(ICustomerRepository repository)
        {
            _repository = repository;
        }


        public void Execute(CustomerDto dto)
        {
            throw new NotImplementedException();
        }

        public void Execute(Guid id, CustomerDto dto)
        {
            var customer = _repository.GetById(id);

            Validate(customer, dto);

            customer.Edit(Name.Create(dto.FirstName, dto.LastName),
                dto.DateOfBirth,
                PhoneNumber.Create(dto.CountryCode, dto.PhoneNumber),
                Email.Create(dto.Email),
                BankAccountNumber.Create(dto.BankAccountNumber));

            _repository.Update(customer);
        }


        private void Validate(Customer customer, CustomerDto dto)
        {
            if (customer == null)
            {
                throw new CustomerNotFoundException();
            }

            var findCustomer = _repository.GetBy(customer.Id, Name.Create(dto.FirstName, dto.LastName), dto.DateOfBirth);

            if (findCustomer != null)
            {
                throw new DuplicateCustomerNameAndDateOfBirthException();
            }

            findCustomer = _repository.GetBy(customer.Id, dto.Email);
            if (findCustomer != null)
            {
                throw new DuplicateCustomerEmailException();
            }
        }
    }
}
