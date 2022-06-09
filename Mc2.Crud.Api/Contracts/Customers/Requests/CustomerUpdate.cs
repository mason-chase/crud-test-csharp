using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Api.Contracts.Customers.Requests
{
    public record CustomerUpdate
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Firstname { get; private set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Lastname { get; private set; }

        [Required]
        public DateTime DateOfBirth { get; private set; }

        [Required]
        [MinLength(7)]
        [MaxLength(10)]
        [Phone]
        public ulong PhoneNumber { get; private set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; private set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string BankAccountNumber { get; private set; }
    }
}
