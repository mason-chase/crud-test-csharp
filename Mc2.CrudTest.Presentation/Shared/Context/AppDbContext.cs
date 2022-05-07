using Mc2.CrudTest.Presentation.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Server.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
                
        }

        public DbSet<Customer> Customers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();
            modelBuilder.Entity<Customer>()
                .HasKey(c => new { c.Firstname, c.Lastname, c.DateOfBirth, c.Id });
            base.OnModelCreating(modelBuilder);
        }
    }
}
