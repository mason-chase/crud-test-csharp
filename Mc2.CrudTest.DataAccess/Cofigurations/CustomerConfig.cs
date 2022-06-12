using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.DataAccess.Cofigurations
{
    internal class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Firstname).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Lastname).HasMaxLength(50).IsRequired();
            builder.Property(c => c.DateOfBirth).HasMaxLength(50).IsRequired();
            builder.Property(c => c.PhoneNumber).HasMaxLength(10).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(50).IsRequired();
            builder.Property(c => c.BankAccountNumber).HasMaxLength(50).IsRequired();

            builder.HasIndex(c => c.Email).IsUnique();
            builder.HasIndex(c => new { c.Firstname, c.Lastname, c.DateOfBirth }).IsUnique();



        }
    }
}
