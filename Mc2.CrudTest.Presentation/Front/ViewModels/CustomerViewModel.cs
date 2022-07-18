using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Presentation.Front.ViewModels
{
    public class CustomerViewModel : IValidatableObject
    {
        public string IdentityGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (!Regex.IsMatch(BankAccountNumber, "((\\d{4})-){3}\\d{4}"))
            {
                yield return new ValidationResult($"BankAccountNumber is not valid",
               new[] { nameof(BankAccountNumber) });
            }

        }
    }
}
