using Mc2.CrudTest.Domain.Validators;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mc2.CrudTest.Domain.Models.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Customer name must required.")]
        [DisplayName("Customer First Name")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Customer lastName must required.")]
        [DisplayName("Customer Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Customer lastName must required.")]
        [DisplayName("Customer Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Customer Phone Number must required.")]
        [PhoneNumber]
        [DisplayName("Customer Phone Number")]
        public ulong PhoneNumber { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Customer Email must required.")]
        [EmailAddress]
        [DisplayName("Customer Email")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Customer Bank Account Number must required.")]
        [RegularExpression("^[0-9-]*$", ErrorMessage = "Banck Account number must be numeric")]
        [BankAccountNumber]
        [DisplayName("Customer Bank Account Number")]
        public string BankAccountNumber { get; set; }
    }
}
