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
    public class BankAccountNumberValidator<T> : PropertyValidator<T, string>, IRegularExpressionValidator
    {
        public string Expression => @"^\d{9,18}$";
        public override string Name => "BankAccountNumberValidator";

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            return Regex.IsMatch(value, Expression);
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return "'{PropertyName}' is not a valid bank account number. account number length varies from 9 digits to 18 digits.";
        }
    }

    public static class BankAccountNumberValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidBankAccountNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var validator = (PropertyValidator<T, string>)new BankAccountNumberValidator<T>();

            return ruleBuilder.SetValidator(validator);
        }
    }
}
