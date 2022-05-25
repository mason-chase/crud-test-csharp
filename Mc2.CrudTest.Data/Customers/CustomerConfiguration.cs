using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Customers
{
    public class MeterStatusChangeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(r => r.Id);

            builder.Property(c => c.Firstname).HasMaxLength(250).IsRequired();
            builder.Property(c => c.Lastname).HasMaxLength(250).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(250).IsRequired();
            builder.Property(c => c.DateOfBirth).HasColumnType("date").IsRequired();
            builder.Property(c => c.PhoneNumber).HasMaxLength(30).IsRequired();

            /// Customers must be unique in database: By Firstname, Lastname and DateOfBirth.
            builder.HasIndex(c => new 
            { 
                c.Firstname, 
                c.Lastname,
                c.DateOfBirth
            }).IsUnique();

            /// Email must be unique in the database.
            builder.HasIndex(c => c.Email).IsUnique();
        }
    }
}
