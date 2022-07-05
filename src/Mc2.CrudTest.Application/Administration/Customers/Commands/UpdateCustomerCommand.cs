using System;
using MediatR;
using System.Linq;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Application.Common.Validators;
using Mc2.CrudTest.Application.Common.Exceptions;

namespace Mc2.CrudTest.Application.Administration.Customers.Commands
{
    #region command

    public class UpdateCustomerCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    #endregion;

    #region validator

    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateCustomerCommandValidator(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(36)
                .WithName("First Name");

            RuleFor(x => x.Lastname)
                .NotEmpty()
                .MaximumLength(36)
                .WithName("Last Name");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MaximumLength(15)
                .ValidPhoneNumber()
                .Must(UniquePhoneNumber).WithMessage("'{PropertyName}' is duplicated.")
                .WithName("Phone Number");

            RuleFor(x => x.Email)
                .NotEmpty()
                .MaximumLength(320)
                .ValidEmailAddress()
                .Must(UniqueEmail).WithMessage("'{PropertyName}' is duplicated.")
                .WithName("Email");

            RuleFor(x => x.BankAccountNumber)
                .NotEmpty()
                .MinimumLength(9)
                .MaximumLength(18)
                .ValidBankAccountNumber()
                .Must(UniqueBankAccountNumber).WithMessage("'{PropertyName}' is duplicated.")
                .WithName("Bank Account Number");

            RuleFor(x => x)
                .Must(UniqueCustomer).WithMessage("Duplicated customer with current FirstName, LastName and DateOfBirth.");

        }

        private bool UniqueEmail(UpdateCustomerCommand command, string email)
        {
            var entity = _dbContext.Customers.Find(command.Id);

            if (entity?.Email == email)
            {
                return true;
            }

            return !_dbContext.Customers.Any(x => x.Email == email);
        }

        private bool UniquePhoneNumber(UpdateCustomerCommand command, string phoneNumber)
        {
            var entity = _dbContext.Customers.Find(command.Id);

            if (entity?.PhoneNumber == phoneNumber)
            {
                return true;
            }

            return !_dbContext.Customers.Any(x => x.PhoneNumber == phoneNumber);
        }

        private bool UniqueBankAccountNumber(UpdateCustomerCommand command, string bankAccountNumber)
        {
            var entity = _dbContext.Customers.Find(command.Id);

            if (entity?.BankAccountNumber == bankAccountNumber)
            {
                return true;
            }

            return !_dbContext.Customers.Any(x => x.BankAccountNumber == bankAccountNumber);
        }

        private bool UniqueCustomer(UpdateCustomerCommand command)
        {
            var entity = _dbContext.Customers.Find(command.Id);

            if (entity?.FirstName == command.FirstName && 
                entity?.Lastname == command.Lastname && 
                entity?.DateOfBirth.Date == command.DateOfBirth.Date)
            {
                return true;
            }

            return !_dbContext.Customers.Any(x =>
                    x.FirstName == command.FirstName &&
                    x.Lastname == command.Lastname &&
                    x.DateOfBirth == command.DateOfBirth);
        }
    }

    #endregion;

    #region handler

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateCustomerCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Customers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            entity.Email = request.Email;
            entity.FirstName = request.FirstName;
            entity.Lastname = request.Lastname;
            entity.PhoneNumber = request.PhoneNumber;
            entity.DateOfBirth = request.DateOfBirth;
            entity.BankAccountNumber = request.BankAccountNumber;

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }

    #endregion;
}
