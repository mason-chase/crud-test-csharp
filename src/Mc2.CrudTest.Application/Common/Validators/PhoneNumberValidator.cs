using System;
using System.Linq;
using System.Text;
using PhoneNumbers;
using FluentValidation;
using System.Threading.Tasks;
using FluentValidation.Results;
using System.Collections.Generic;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Application.Common.Validators
{
    public class PhoneNumberValidator<T> : PropertyValidator<T, string>, IRegularExpressionValidator
    {
        public override string Name => "PhoneNumberValidator";
        public string Expression => @"^(\+)[1-9]{1}([0-9][\s]*){9,16}$";

        public override bool IsValid(ValidationContext<T> context, string value)
        {
             var isValidPhoneNumber = Regex.IsMatch(value, Expression);

            if (isValidPhoneNumber)
            {
                var phoneNumberValidator = PhoneNumberUtil.GetInstance();

                try
                {
                    phoneNumberValidator.Parse(value, string.Empty);

                    return true;
                }
                catch(NumberParseException ex)
                {
                    context.AddFailure(new ValidationFailure
                    {
                         ErrorMessage = "The phone number is not in international format. Example for US: +1 XXX XXX XXXX.",
                    });
                }
            }

            return false;
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return "'{PropertyName}' is not a valid number.";
        }
    }

    public static class PhoneNumberValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidPhoneNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var validator = (PropertyValidator<T, string>)new PhoneNumberValidator<T>();

            return ruleBuilder.SetValidator(validator);
        }
    }
}
