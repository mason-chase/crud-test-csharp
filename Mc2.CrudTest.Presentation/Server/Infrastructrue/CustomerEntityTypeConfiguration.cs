namespace Infrastructure.EntityConfigurations
{
   class BuyerEntityTypeConfiguration
    : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> customerConfiguration)
    {
        customerConfiguration.ToTable("customers", CustomerContext.DEFAULT_SCHEMA);

        customerConfiguration.HasKey(b => b.Id);

        customerConfiguration.Ignore(b => b.DomainEvents);

        customerConfiguration.Property(b => b.Id)
            .UseHiLo("customerseq", CustomerContext.DEFAULT_SCHEMA);

        // make firstName, LastName, Email unique by default
        customerConfiguration.HasIndex(b => "DateOfBirth","FirstName","LastName")
            .IsUnique(true);

        // make sure email is unique
        customerConfiguration.HasIndex(b => b.Email)
            .IsUnique(true);

        customerConfiguration.Property(b => b.IdentityGuid)
            .HasMaxLength(200)
            .IsRequired();

        customerConfiguration.HasIndex("IdentityGuid")
            .IsUnique(true);

        customerConfiguration.Property(b => b.Name);

        customerConfiguration.Property(b => b.Firstname)
            .HasMaxLength(200)
            .IsRequired();

        customerConfiguration.Property(b => b.Lastname)
            .HasMaxLength(200)
            .IsRequired();

        customerConfiguration.Property(b => b.DateOfBirth)
            .IsRequired();

        customerConfiguration.Property(b => b.PhoneNumber)
            .HasMaxLength(200)
            .IsRequired();

        customerConfiguration.Property(b => b.Email)
            .HasMaxLength(200)
            .IsRequired();

        customerConfiguration.Property(b => b.BankAccountNumber)
            .HasMaxLength(200)
            .IsRequired();

    }
} 
}