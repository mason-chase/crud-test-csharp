using Mc2.CrudTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions opt) : base(opt) { var a = this.Database.GetDbConnection().ConnectionString; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasKey(table => new
            {
                table.Id,
                table.FirstName,
                table.LastName,
                table.DateOfBirth
            });

            builder.Entity<Customer>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
