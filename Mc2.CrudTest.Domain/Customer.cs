using System;
using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Domain
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [Key]
        public string FirstName { get; set; }

        [Key]
        public string LastName { get; set; }

        [Key]
        public DateTime DateOfBirth { get; set; }

        [StringLength(13)]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Banck account number must be numeric")]
        public string BanckAccountNumber { get; set; }
    }
}
