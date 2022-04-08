using Mc2.CrudTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Database;

public sealed class customerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer), nameof(Customer));

        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(customer => customer.PhoneNumber).HasMaxLength(20).IsRequired();
        builder.Property(customer => customer.BankAccountNumber).HasMaxLength(30).IsRequired();


        builder.OwnsOne(customer => customer.Name, userInfo =>
        {
            userInfo.Property(name => name.FirstName).HasColumnName(nameof(Name.FirstName)).HasMaxLength(100).IsRequired();

            userInfo.Property(name => name.LastName).HasColumnName(nameof(Name.LastName)).HasMaxLength(200).IsRequired();

            userInfo.Property(name => name.DateOfBirth).HasColumnName(nameof(Name.DateOfBirth)).HasMaxLength(300).IsRequired();

            userInfo.HasIndex(_userInfo => new { _userInfo.FirstName, _userInfo.LastName, _userInfo.DateOfBirth }).IsUnique();
        });
        builder.OwnsOne(customer => customer.Email, customerEmail =>
        {
            customerEmail.Property(email => email.Value).HasColumnName(nameof(Email)).HasMaxLength(300).IsRequired();

            customerEmail.HasIndex(email => email.Value).IsUnique();
        });

    }
}
