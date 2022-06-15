using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.persistence.ApplicationDbContext.EntitiesConfiguration.CustomerConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Customer> builder)
        {
            #region Key
            builder.HasKey(a => a.Id);
            #endregion

            #region Configuration
            builder.Property(a => a.Firstname).HasMaxLength(60).IsRequired();
            builder.Property(a => a.Lastname).HasMaxLength(80).IsRequired();
            builder.Property(a => a.PhoneNumber).HasMaxLength(15);
            builder.Property(a => a.BankAccountNumber).HasMaxLength(30);
            builder.Property(a => a.Email).HasMaxLength(150).IsRequired();
            builder.Property(a => a.DateOfBirth).HasMaxLength(10).IsRequired();
            #endregion
        }
    }
}
