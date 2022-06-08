using System;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.DTO;

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
    [MaxLength(15)]
    [Phone(ErrorMessage = "Entered Phone Number is not Valid!")]
    public string PhoneNumber { get; set; }
    [MaxLength(25)]
    public string BankAccountNumber { get; set; }
}
