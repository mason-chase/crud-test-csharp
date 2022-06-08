using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.Models;
using MediatR;

namespace CleanArchitecture.Application.Handler;

public class AddCustomerHandler : IRequestHandler<AddCustomerCommand, Customer>
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
        if (!customerModel.Email.IsValidEmailAddress())
            throw new NotValidEmail();
        if (!customerModel.PhoneNumber.PhoneIsValid())
            throw new NotValidPhoneNumber();
        if (!customerModel.BankAccountNumber.IsValidBankAccount())
            throw new NotValidBankAccountNumber();

        try
        {
            await _repository.AddAsync(customerModel);
            await _repository.SaveChanges();
        }
        catch (Exception)
        {
            return null;
        }

        return customerModel;
    }
}
