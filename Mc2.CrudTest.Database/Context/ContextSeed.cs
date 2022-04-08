using Mc2.CrudTest.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Mc2.CrudTests.Database;

public static class ContextSeed
{
    public static void Seed(this ModelBuilder builder)
    {
        builder.SeedCustomers();
    }

    private static void SeedCustomers(this ModelBuilder builder)
    {
        builder.Entity<Customer>(Customer =>
        {
            Customer.HasData(new
            {
                Id = 1L,
                BankAccountNumber="6037997435104287",
                PhoneNumber ="0913906453"
            });

            Customer.OwnsOne(CustomerName => CustomerName.Name).HasData(new
            {
                CustomerId = 1L,
                FirstName = "Ehsan",
                LastName = "karimi",
                DateOfBirth = new DateTime(1987,01,20)
            }) ;

            Customer.OwnsOne(CustomerEmail => CustomerEmail.Email).HasData(new
            {
                CustomerId = 1L,
                Value = "karimy.ehsan@gmail.com"
            });
        });
    }
}
