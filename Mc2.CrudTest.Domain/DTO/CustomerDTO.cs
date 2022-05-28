namespace Mc2.CrudTest.Domain.DTO;
public record CustomerDTO(
    Guid Id,
    string FirstName,
    string LastName,
    DateTimeOffset DateOfBirth,
    string PhoneNumber,
    string CountryCodeSelected,
    string Email,
    string BankAccountNumber)
;
public class CustomerDTO2
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public string CountryCodeSelected { get; set; }
    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}