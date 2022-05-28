using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Domain.DTO;

public class CreateCustomerDTO
{
    [Required]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string CountryCodeSelected { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}