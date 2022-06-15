using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Application.Common.Interfaces.DbContext
{
    public interface IApplicationDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        DbSet<TEntity> SetDbContext<TEntity>() where TEntity : class;
        void SaveChanges();
        void Entry<TEntity>(TEntity entity);
    }
}
