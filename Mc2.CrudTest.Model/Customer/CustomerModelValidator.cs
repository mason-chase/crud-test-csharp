using FluentValidation;
using libphonenumber;
using Mc2.CrudTest.Model.Customer;

namespace Mc2.CrudTest.Model;

public abstract class CustomerModelValidator : AbstractValidator<CustomerModel>
{
    public CustomerModelValidator()
    {
    }
    public void Id() => RuleFor(customer => customer.Id).NotEmpty();

    public void FirstName() => RuleFor(customer => customer.FirstName).NotEmpty();

    public void LastName() => RuleFor(customer => customer.LastName).NotEmpty();

    public void Email() => RuleFor(customer => customer.Email).EmailAddress();

    public void DateOfBirth() => RuleFor(customer => customer.DateOfBirth).NotEmpty();

    public void PhoneNumber() => RuleFor(customer => customer.PhoneNumber).NotEmpty().PhoneNumber();

    public void BankAccountNumber() => RuleFor(customer => customer.BankAccountNumber).NotEmpty();

}
