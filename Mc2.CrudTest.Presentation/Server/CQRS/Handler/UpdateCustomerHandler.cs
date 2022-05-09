using System;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Presentation.Server.CQRS.Commands;
using Mc2.CrudTest.Shared.Common;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Queries
{
    public class UpdateCustomerHandler: IRequestHandler<UpdateCustomerCommand, bool>
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
                    throw new NotValidEmail();
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
}
