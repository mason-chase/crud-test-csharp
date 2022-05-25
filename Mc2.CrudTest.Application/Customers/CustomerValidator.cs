using FluentValidation;
using FluentValidation.Validators;
using Mc2.CrudTest.Domain;

namespace Mc2.CrudTest.Application.Customers
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty().Length(13);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.BanckAccountNumber).Matches("^\\d{16}$");
        }
    }
}