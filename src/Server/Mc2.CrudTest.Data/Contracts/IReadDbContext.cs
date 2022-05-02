using Mc2.CrudTest.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Mc2.CrudTest.Data.Contracts
{
    public interface IReadDbContext : IDisposable
    {
        DbSet<Customer> Customers { get; }
    }
}
