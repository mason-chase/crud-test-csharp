
using Mc2.CrudTest.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Mc2.CrudTest.Context
{
    public class MC2Context : DbContext
    {
        public MC2Context()
        {

        }

        public MC2Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MC2DB;Persist Security Info=True;User ID=sa;Password=123456;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
       
        public void DetachAllEntities()
        {
            var changedEntriesCopy = ChangeTracker.Entries().ToList();
            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

    }
}
