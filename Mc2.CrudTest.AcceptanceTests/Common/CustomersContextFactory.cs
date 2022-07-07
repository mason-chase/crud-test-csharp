using Mc2.CrudTest.Domain.Models.Entities;
using Mc2.CrudTest.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace Mc2.CrudTest.AcceptanceTests.Common
{
    public class CustomersContextFactory
    {
        public static CustomerDbContext Create()
        {
            var options = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new CustomerDbContext(options);
            context.Database.EnsureCreated();
            context.Customers.AddRange(
                new CustomerEntity()
                {
                    FirstName = "Taher 1",
                    LastName = "Fattahi 1",
                    DateOfBirth = new DateTime(2022, 3, 22, 6, 0, 0),
                    PhoneNumber = 989115467885,
                    Email = "taherfatta11@gmail.com",
                    BankAccountNumber = "6037-9917-0000-0000"
                },
                new CustomerEntity()
                {
                    FirstName = "Taher 2",
                    LastName = "Fattahi 2",
                    DateOfBirth = new DateTime(2022, 9, 22, 6, 0, 0),
                    PhoneNumber = 989115467886,
                    Email = "taherfatta111@gmail.com",
                    BankAccountNumber = "6037-9917-0000-0000"
                },
                new CustomerEntity()
                {
                    FirstName = "Taher 3",
                    LastName = "Fattahi 3",
                    DateOfBirth = new DateTime(2022, 8, 22, 6, 0, 1),
                    PhoneNumber = 989115467887,
                    Email = "taherfatta1111@gmail.com",
                    BankAccountNumber = "6037-9917-0000-0000"
                },
                new CustomerEntity()
                {
                    FirstName = "Taher 4",
                    LastName = "Fattahi 4",
                    DateOfBirth = new DateTime(2022, 1, 22, 6, 0, 0),
                    PhoneNumber = 989115467888,
                    Email = "taherfatta11111@gmail.com",
                    BankAccountNumber = "6037-9917-0000-0000"
                });
            context.SaveChanges();
            return context;
        }

        public static void Destroy(CustomerDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
