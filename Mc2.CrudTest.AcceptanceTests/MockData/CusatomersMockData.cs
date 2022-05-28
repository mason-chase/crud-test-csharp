using Mc2.CrudTest.Domain.DTO;
using Mc2.CrudTest.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Mc2.CrudTest.AcceptanceTests.MockData;

public class CusatomersMockData
{
    public static List<Customer> GetCustomers() => new()
    {
        new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = "Sinjul01",
            LastName = "MSBH01",
            DateOfBirth = DateTimeOffset.UtcNow,
            Email = "sinjul.msbh01@yahoo.com",
            PhoneNumber = "+44 123 456 801",
            CountryCodeSelected = "US",
            BankAccountNumber = "1",
        },
        new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = "Sinjul02",
            LastName = "MSBH02",
            DateOfBirth = DateTimeOffset.UtcNow,
            Email = "sinjul.msbh02@yahoo.com",
            PhoneNumber = "+44 123 456 802",
            CountryCodeSelected = "US",
            BankAccountNumber = "2",
        },
        new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = "Sinjul03",
            LastName = "MSBH03",
            DateOfBirth = DateTimeOffset.UtcNow,
            Email = "sinjul.msbh03@yahoo.com",
            PhoneNumber = "+44 123 456 803",
            CountryCodeSelected = "US",
            BankAccountNumber = "3",
        },
        new Customer
        {
            Id = Guid.NewGuid(),
            FirstName = "Sinjul04",
            LastName = "MSBH04",
            DateOfBirth = DateTimeOffset.UtcNow,
            Email = "sinjul.msbh04@yahoo.com",
            PhoneNumber = "+44 123 456 804",
            CountryCodeSelected = "US",
            BankAccountNumber = "4",
        },
    };

    public static List<Customer> GetEmptyCustomers() => new();

    public static Customer NewCustomer() => new()
    {
        FirstName = "Sinjul",
        LastName = "MSBH",
        DateOfBirth = DateTimeOffset.UtcNow,
        Email = "sinjul.msbh@yahoo.com",
        PhoneNumber = "+44 123 456 800",
        CountryCodeSelected = "US",
        BankAccountNumber = "13",
    };
}
