using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.FirstName)
                .HasMaxLength(36);

            builder.Property(x => x.Lastname)
                .HasMaxLength(36);

            builder.Property(x => x.Email)
                .HasMaxLength(320);

            builder.Property(x => x.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(x => x.BankAccountNumber)
                .HasMaxLength(18)
                .IsRequired();
        }
    }
}
