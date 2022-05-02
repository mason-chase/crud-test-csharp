using Mc2.CrudTest.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Data.EntityMaps
{
    public class CustomerEntityMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");

            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id)
                .ValueGeneratedNever()
                .UsePropertyAccessMode(PropertyAccessMode.Property);

            builder.OwnsOne(_ => _.Name,
                 _ =>
                 {
                     _.Property(_ => _.First)
                          .HasColumnName("FirstName")
                          .IsRequired()
                          .IsUnicode()
                          .HasMaxLength(50)
                          .IsFixedLength(true)
                          .UsePropertyAccessMode(PropertyAccessMode.Property);
                     _.Property(_ => _.Last)
                          .HasColumnName("LastName")
                          .IsRequired()
                          .IsUnicode()
                           .HasMaxLength(50)
                          .IsFixedLength(true)
                          .UsePropertyAccessMode(PropertyAccessMode.Property);
                 }).UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);

            builder.OwnsOne(_ => _.PhoneNumber,
               _ =>
               {
                   _.Property(_ => _.CountryCode)
                        .HasColumnName("CountryCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsFixedLength(true)
                        .UsePropertyAccessMode(PropertyAccessMode.Property);
                   _.Property(_ => _.Number)
                        .HasColumnName("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsFixedLength(true)
                        .UsePropertyAccessMode(PropertyAccessMode.Property);
               }).UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);


            builder.OwnsOne(_ => _.Email,
             _ =>
             {
                 _.Property(_ => _.Value)
                      .HasColumnName("Email")
                      .IsRequired()
                      .UsePropertyAccessMode(PropertyAccessMode.Property);
             }).UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);


            builder.OwnsOne(_ => _.BankAccountNumber,
            _ =>
            {
                _.Property(_ => _.Value)
                     .HasColumnName("BankAccountNumber")
                     .IsRequired()
                     .UsePropertyAccessMode(PropertyAccessMode.Property);
            }).UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);


        }
    }
}
