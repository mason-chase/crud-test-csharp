using System;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.AcceptanceTests.Contracts.Customers.Requests
{
    public record CustomerCreate
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Firstname { get; set; } = String.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Lastname { get; set; } = String.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MinLength(7)]
        [MaxLength(10)]
        [Phone]
        public ulong PhoneNumber { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; } = String.Empty;

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string BankAccountNumber { get; set; } = String.Empty;
    }
}
