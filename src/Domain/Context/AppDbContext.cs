using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Domain.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasIndex(c => new
            {
                c.Email,
                c.Firstname,
                c.DateOfBirth
            })
            .IsUnique();
        modelBuilder.Entity<Customer>()
            .HasKey(c => new { c.Id });
        base.OnModelCreating(modelBuilder);
    }
}
