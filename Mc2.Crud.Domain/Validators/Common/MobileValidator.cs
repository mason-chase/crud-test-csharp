using FluentValidation;
using PhoneNumbers;

namespace Mc2.CrudTest.Domain.Validators.Common;

public class MobileValidator : AbstractValidator<ulong>
{
    public MobileValidator()
    {
        // because we didnt had a filed for region, I supposed all phone number are form US.
        PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
        RuleFor(phoneNumber => phoneNumber).Must(p => phoneUtil.IsValidNumber(phoneUtil.Parse(p.ToString(), "US")))
            .WithMessage("Provided phone number is not valid !");
    }

    //created by mason.
    public static bool Validate(ulong phoneNumber, string region)
    {
        PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
        PhoneNumbers.PhoneNumber phone = phoneUtil.Parse(phoneNumber.ToString(), region);
        var res = phoneUtil.IsValidNumber(phone);
        return res;
    }


}