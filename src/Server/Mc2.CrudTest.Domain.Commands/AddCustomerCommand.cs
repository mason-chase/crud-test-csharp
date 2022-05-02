using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Repositories;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.Domain.Model.Exceptions;
using Mc2.CrudTest.Domain.Model.ValueObject;
using System;

namespace Mc2.CrudTest.Domain.Commands
{
    public class AddCustomerCommand : IAddCustomerCommand
    {
        private readonly ICustomerRepository _repository;
        public AddCustomerCommand(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public void Execute(CustomerDto dto)
        {
            throw new NotImplementedException();
        }

        public void Execute(Guid id, CustomerDto dto)
        {
            Validate(id, dto);

            var entity = Customer.Create(id, Name.Create(dto.FirstName, dto.LastName), dto.DateOfBirth,
               PhoneNumber.Create(dto.CountryCode, dto.PhoneNumber),
               Email.Create(dto.Email), BankAccountNumber.Create(dto.BankAccountNumber));

            _repository.Add(entity);
        }

        private void Validate(Guid id, CustomerDto dto)
        {
            var customer = _repository.GetBy(id, Name.Create(dto.FirstName, dto.LastName), dto.DateOfBirth);

            if (customer != null)
            {
                throw new DuplicateCustomerNameAndDateOfBirthException();
            }

            customer = _repository.GetBy(id, dto.Email);
            if (customer != null)
            {
                throw new DuplicateCustomerEmailException();
            }
        }

    }
}
