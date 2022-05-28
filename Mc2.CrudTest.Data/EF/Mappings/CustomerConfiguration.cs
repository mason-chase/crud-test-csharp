using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Data.EF.Mappings;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        //builder.ToTabl(TableMappingNameConst.PluralName.Customers, TableMappingNameConst.SchemaName.Mc2);

        /*.HasIndex(u => u.Email).IsUnique(true)*/
        //.HasDatabaseName("EmailIndex").IsUnique()
        // Key => FirstName LastName DateOfBirth

        builder.HasKey(c => c.Id);

        builder.Property(c => c.FirstName).IsRequired(true).HasMaxLength(94);

        builder.Property(c => c.LastName).IsRequired(true).HasMaxLength(130);

        builder.Property(c => c.DateOfBirth).IsRequired(true);

        builder.Property(c => c.PhoneNumber).IsRequired(false).HasMaxLength(13);

        builder.Property(c => c.Email).IsRequired(false).HasMaxLength(103);

        builder.Property(c => c.BankAccountNumber);

        var customers = new Customer[]
        {
            new Customer{
                Id = Guid.NewGuid(),
                FirstName = "Sinjul" ,
                LastName = "MSBH" ,
                DateOfBirth = DateTimeOffset.UtcNow,
                Email = "sinjul.msbh@yahoo.com" ,
                PhoneNumber = "09215892274" ,
                CountryCodeSelected = "US",
                BankAccountNumber = "1234",
            }
        };

        builder.HasData(customers);
    }
}