using Mc2.CrudTest.Domain.Models.Entities;
using Mc2.CrudTest.Persistence.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Persistence
{
    public class CustomerDbContext : DbContext, ICustomerDbContext
    {
        public DbSet<CustomerEntity> Customers { get; set; }

        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerEntity>()
                .HasIndex(table => new { table.Email, table.FirstName, table.LastName, table.DateOfBirth }).IsUnique();

            builder.Entity<CustomerEntity>().HasData(
                 new CustomerEntity()
                 {
                     Id = 1,
                     FirstName = "Taher 1".ToLower(),
                     LastName = "Fattahi 1".ToLower(),
                     DateOfBirth = new DateTime(2022, 3, 15, 6, 0, 0),
                     PhoneNumber = 989115467885,
                     Email = "taherfatta11@gmail.com".ToLower(),
                     BankAccountNumber = "6037-9917-0000-0000"
                 },
                new CustomerEntity()
                {
                    Id = 2,
                    FirstName = "Taher 2".ToLower(),
                    LastName = "Fattahi 2".ToLower(),
                    DateOfBirth = new DateTime(2022, 9, 16, 6, 0, 0),
                    PhoneNumber = 989115467886,
                    Email = "taherfatta111@gmail.com".ToLower(),
                    BankAccountNumber = "6037-9917-0000-0000"
                },
                new CustomerEntity()
                {
                    Id = 3,
                    FirstName = "Taher 3".ToLower(),
                    LastName = "Fattahi 3".ToLower(),
                    DateOfBirth = new DateTime(2022, 8, 17, 6, 0, 1),
                    PhoneNumber = 989115467887,
                    Email = "taherfatta1111@gmail.com".ToLower(),
                    BankAccountNumber = "6037-9917-0000-0000"
                },
                new CustomerEntity()
                {
                    Id = 4,
                    FirstName = "Taher 4".ToLower(),
                    LastName = "Fattahi 4".ToLower(),
                    DateOfBirth = new DateTime(2022, 1, 18, 6, 0, 0),
                    PhoneNumber = 989115467888,
                    Email = "taherfatta11111@gmail.com".ToLower(),
                    BankAccountNumber = "6037-9917-0000-0000"
                }
            );

        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

    }
}
