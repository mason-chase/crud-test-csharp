using FluentValidation;
using FluentValidation.Validators;
using libphonenumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Model.Customer
{
    public class PhoneValidator<T, TProperty> : PropertyValidator<T, TProperty>
    {
        public PhoneValidator()
        {
        }
        public override bool IsValid(ValidationContext<T> context, TProperty phoneNumber)
        {
            string _phoneNumber = phoneNumber.ToString();
            _phoneNumber = _phoneNumber.Trim();

            bool result;
            try
            {
                result = PhoneNumberUtil.Instance.Parse(_phoneNumber, "").IsValidNumber;
            }
            catch
            {
                return false;
            }
            return result;
        }

        public override string Name => "PhoneNumberValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "{PropertyName} is not in correct Format.";
    }
    public static class PhoneValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TElement> PhoneNumber<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new PhoneValidator<T, TElement>());
        }
    }
}
