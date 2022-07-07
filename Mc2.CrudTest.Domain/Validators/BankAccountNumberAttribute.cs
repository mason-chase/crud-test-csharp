using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Domain.Validators
{
    public class BankAccountNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object banlNumber,
            ValidationContext validationContext)
        {
            //string input = "0000-0000-0000-0000";
            if (BankAccountNumberValidator.Validate(banlNumber.ToString().Trim()))
                return ValidationResult.Success;
            return new ValidationResult("Please Enter Valid Bank Account Number");
        }
    }
}