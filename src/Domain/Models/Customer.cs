using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Domain.Models;

public class Customer
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Firstname { get; set; }
    [Required]
    public string Lastname { get; set; }
    [Required]
    public DateTime DateOfBirth { get; set; }
    [MaxLength(15)]
    /*[RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Mobile Number Format Is Invalid!")]*/
    public string PhoneNumber { get; set; }
    [MaxLength(25)]
    public string BankAccountNumber { get; set; }
}
