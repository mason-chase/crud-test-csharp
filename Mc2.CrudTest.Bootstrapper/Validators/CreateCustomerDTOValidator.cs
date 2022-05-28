using FluentValidation;
using Mc2.CrudTest.Domain.DTO;
using Mc2.CrudTest.Services.Interfaces;
using PhoneNumbers;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Bootstrapper.Behaviors;

public class CreateCustomerDTOValidator : AbstractValidator<CreateCustomerDTO>
{
    public ICustomerService CustomerService { get; }

    public CreateCustomerDTOValidator(ICustomerService customerService!!)
    {
        CustomerService = customerService;

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage("You must enter a email address ..")
            .NotNull().WithMessage("Email address is required ..")
            .EmailAddress().WithMessage("You must provide a valid email address ..")
            .EmailUnique(customerService).WithMessage("EmailUnique must be unique ..")
            //.MustAsync(async (email, _) => await IsUniqueAsync(email)).WithMessage("Email address must be unique").When(p => !string.IsNullOrEmpty(p.Email))
        ;

        static async Task<bool> IsUniqueAsync(string email)
        {
            await Task.Delay(13);

            return email.ToLower() != "mail@my.com";
        }

        RuleFor(c => c.PhoneNumber)
           .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters ..")
           .MaximumLength(50).WithMessage("PhoneNumber must not exceed 50 characters ..")
           .NotEmpty().WithMessage("PhoneNumber is required ..")
           .NotNull().WithMessage("PhoneNumber is required ..")
           .Must(PhoneNumberValid).WithMessage("PhoneNumber not valid .. !!!!")
        //.Matches(new Regex(@"^([\+]?33[-]?|[0])?[1-9][0-9]{8}$")) //international phone numbers
        //.WithMessage("PhoneNumber not valid .. !!!!")
        ;

        static bool PhoneNumberValid(string phoneNumberRaw)
        {
            try
            {
                var phoneNumberUtil = PhoneNumberUtil.GetInstance();

                PhoneNumber queryPhoneNumber = phoneNumberUtil.Parse(phoneNumberRaw, null);

                var result = phoneNumberUtil.IsValidNumber(queryPhoneNumber);

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        RuleFor(c => c.CountryCodeSelected)
           .NotNull().WithMessage("CountryCodeSelected is required ..")
           .NotEmpty().WithMessage("CountryCodeSelected is required ..")
           .Length(2, 3).WithMessage("Minimum of {0} and Maximum of {1} characters ..")
        //.Must((p, n) => n.Any(c => c == ' ')).WithMessage("must contain first and last name ..")
        ;

        RuleFor(p => p.FirstName)
           .NotNull().WithMessage("Firstname is required ..")
           .NotEmpty().WithMessage("Firstname is required ..")
           .Length(3, 40).WithMessage("Minimum of {0} and Maximum of {1} characters ..")
        ;

        RuleFor(c => c.LastName)
           .NotNull().WithMessage("Lastname is required ..")
           .NotEmpty().WithMessage("FirsLastnametname is required ..")
           .Length(3, 40).WithMessage("Minimum of {0} and Maximum of {1} characters ..")
        ;

        RuleFor(p => p.DateOfBirth)
            .NotEmpty().WithMessage("DateOfBirth is required ..")
            .NotNull().WithMessage("Complete DateOfBirth is not a valid date ..")
            .Must(BeAValidDate).WithMessage("Start date is required ..")
            .LessThan(p => DateTimeOffset.UtcNow).WithMessage("The date must be in the past ..")
        ;

        static bool BeAValidDate(DateTimeOffset date) => !date.Equals(default);

        RuleFor(c => c.BankAccountNumber)
            .NotEmpty().WithMessage("BankAccountNumber is required ..")
            .Matches(new Regex(@"^[0-9]*$")).WithMessage("BankAccountNumber must be numeric .. !!!!")
        ;
    }
}