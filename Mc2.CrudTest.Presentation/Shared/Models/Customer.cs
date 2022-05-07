using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mc2.CrudTest.Presentation.Server.Models
{
    public class Customer
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
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
        public string PhoneNumber { get; set; }
        [MaxLength(30)]
        public string BankAccountNumber { get; set; }
    }
}
