using System;
using System.Linq;
using System.Text;
using FluentValidation;
using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Application.Common.Validators
{
    public class EmailAddressValidator<T> : PropertyValidator<T, string>, IRegularExpressionValidator
    {
        public override string Name => "EmailValidator";

        public string Expression => @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            if(value == null)
            {
                return false;
            }

            return Regex.IsMatch(value, Expression);
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return Localized(errorCode, Name);
        }
    }

    public static class EmailAddressValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidEmailAddress<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var validator = (PropertyValidator<T, string>)new EmailAddressValidator<T>();

            return ruleBuilder.SetValidator(validator);
        }
    }
}
