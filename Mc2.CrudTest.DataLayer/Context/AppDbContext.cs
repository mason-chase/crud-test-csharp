using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.DataLayer.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        #region Entities

        public DbSet<Customer> Customers { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Fluent API

            modelBuilder.Entity<Customer>()
                .Property(c => c.PhoneNumber)
                .HasColumnType("varchar(50)");

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasKey(c => new { c.Firstname, c.Lastname, c.DateOfBirth });

            #endregion
        }
    }
}
