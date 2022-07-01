using FluentValidation;
using Mc2.CrudTest.Domain.Entities;
using PhoneNumbers;

namespace Mc2.CrudTest.Domain.Validators.CustomerValidators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(customer => customer.Firstname).NotNull().WithMessage("FirstName is required !")
                .MinimumLength(2).WithMessage("FirstName must be at least 2 characters !")
                .MaximumLength(50).WithMessage("FirstName could not be more than 50 charactrs !");

            RuleFor(customer => customer.Lastname).NotNull().WithMessage("Lastname is required !")
                .MinimumLength(2).WithMessage("Lastname must be at least 2 characters !")
                .MaximumLength(50).WithMessage("Lastname could not be more than 50 charactrs !");

            RuleFor(customer => customer.BankAccountNumber).NotNull().WithMessage("BankAccountNumber is required !")
                .MinimumLength(2).WithMessage("BankAccountNumber must be at least 2 characters !");

            RuleFor(customer => customer.Email).NotNull().WithMessage("Email is required !")
                .MaximumLength(50).WithMessage("Email could not be more than 50 charactrs !")
                .EmailAddress().WithMessage("Provided Email is not formated corrrectly !");

            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            RuleFor(customer => customer.PhoneNumber)
                .NotNull().WithMessage("PhoneNumber is required !")
                .Must(p => phoneUtil.IsValidNumber(phoneUtil.Parse(p.ToString(), "US")))
                .WithMessage("Provided phone number is not valid !");

        }
    }
}
