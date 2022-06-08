using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Exceptions;
using MediatR;

namespace CleanArchitecture.Application.Handler;

public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, bool>
{
    private readonly ICustomerRepository _repository;
    public UpdateCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }
    public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (!request.customer.Email.IsValidEmailAddress())
                throw new NotValidEmail();
            if (!request.customer.PhoneNumber.PhoneIsValid())
                throw new NotValidPhoneNumber();
            if (!request.customer.BankAccountNumber.IsValidBankAccount())
                throw new NotValidBankAccountNumber();

            _repository.Update(request.customer);
            await _repository.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}
