using System;

namespace Mc2.CrudTest.Model;

public sealed record CustomerModel
{
    public long Id { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

    public DateTime DateOfBirth { get; init; }

    public string PhoneNumber { get; init; }

    public string Email { get; init; }

    public string BankAccountNumber { get; init; }

}
