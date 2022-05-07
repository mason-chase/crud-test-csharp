using System;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Domain.DTO
{
    public class CustomerDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Entered Email is not Valid!")]
        public string Email { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Phone(ErrorMessage = "Entered Phone Number is not Valid!")]
        [MaxLength(15)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Mobile Number Format Is Invalid!")]
        public string PhoneNumber { get; set; }
        [MaxLength(17)]
        public string BankAccountNumber { get; set; }
    }
}
