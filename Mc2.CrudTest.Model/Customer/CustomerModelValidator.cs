using FluentValidation;
using libphonenumber;

namespace Mc2.CrudTest.Model;

public abstract class CustomerModelValidator : AbstractValidator<CustomerModel>
{
    private readonly PhoneNumber _phoneNumberValidator;
    public CustomerModelValidator()
    {
        _phoneNumberValidator = new PhoneNumber();
    }
    public void Id() => RuleFor(customer => customer.Id).NotEmpty();

    public void FirstName() => RuleFor(customer => customer.FirstName).NotEmpty();

    public void LastName() => RuleFor(customer => customer.LastName).NotEmpty();

    public void Email() => RuleFor(customer => customer.Email).EmailAddress();

    public void DateOfBirth() => RuleFor(customer => customer.DateOfBirth).NotEmpty();

    public void PhoneNumber() => RuleFor(customer => customer.PhoneNumber).NotEmpty().Custom((phoneNumber, context) =>
    {
        bool result = false;

        phoneNumber = phoneNumber.Trim();

        if (phoneNumber.StartsWith("00"))
            phoneNumber = "+" + phoneNumber.Remove(0, 2);

        try
        {
            result = PhoneNumberUtil.Instance.Parse(phoneNumber, "").IsValidNumber;
        }
        catch
        {
            context.AddFailure("phone number is not in correct Format");
            return;
        }
        if (!result)
            context.AddFailure("phone number is not in correct Format");
    });

    public void BankAccountNumber() => RuleFor(customer => customer.BankAccountNumber).NotEmpty();

}
