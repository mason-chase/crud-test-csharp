using Mc2.CrudTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence
{
    public interface IDataContext
    {
        DbSet<Customer> Customers { get; set; }

        Task<int> SaveChangesAsync();

        DbSet<T> Set<T>() where T : class;
    }
}