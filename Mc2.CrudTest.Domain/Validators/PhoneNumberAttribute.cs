using System;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Domain.Validators
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if (MobileValidator.Validate(value.ToString()!))
                return ValidationResult.Success!;
            return new ValidationResult("Please Enter Correct Phone Number");
        }
    }
}
