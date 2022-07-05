using System;
using MediatR;
using System.Linq;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Application.Common.Validators;

namespace Mc2.CrudTest.Application.Administration.Customers.Commands
{
    #region command

    public class CreateCustomerCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BankAccountNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    #endregion;

    #region validator

    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateCustomerCommandValidator(IApplicationDbContext dbContext)
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

        private bool UniqueEmail(string email)
        {
            return !_dbContext.Customers.Any(x => x.Email == email);
        }

        private bool UniquePhoneNumber(string phoneNumber)
        {
            return !_dbContext.Customers.Any(x => x.PhoneNumber == phoneNumber);
        }

        private bool UniqueBankAccountNumber(string bankAccountNumber)
        {
            return !_dbContext.Customers.Any(x => x.BankAccountNumber == bankAccountNumber);
        }

        private bool UniqueCustomer(CreateCustomerCommand command)
        {
            return !_dbContext.Customers.Any(x =>
                    x.FirstName == command.FirstName &&
                    x.Lastname == command.Lastname &&
                    x.DateOfBirth.Date == command.DateOfBirth.Date);
        }
    }

    #endregion;

    #region handler

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateCustomerCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Customer
            {
                Email = request.Email,
                Lastname = request.Lastname,
                FirstName = request.FirstName,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth,
                BankAccountNumber = request.BankAccountNumber,
            };

            _dbContext.Customers.Add(entity);

            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }
    }

    #endregion;
}
