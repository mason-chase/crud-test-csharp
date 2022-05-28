using Mc2.CrudTest.Domain.Common;

namespace Mc2.CrudTest.Domain.Entities;

public class Customer: BaseEntity<Guid>
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;

    public DateTimeOffset DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }

    // Iran (Islamic Republic of) => IR IRN 364
    // United States of America(the) => US USA 840
    private string? _countryCodeSelected = "US";
    public string CountryCodeSelected
    {
        get => _countryCodeSelected;

        set => _countryCodeSelected = value.ToUpperInvariant();
    }

    public string Email { get; set; }
    public string BankAccountNumber { get; set; }
}