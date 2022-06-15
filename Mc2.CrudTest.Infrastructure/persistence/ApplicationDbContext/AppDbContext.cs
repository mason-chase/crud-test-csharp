

using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Infrastructure.persistence.ApplicationDbContext
{
    public class AppDbContext : DbContext, IApplicationDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TEntity> SetDbContext<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }


        public void SaveChanges()
        {
            base.SaveChanges();
        }

        public void Entry<TEntity>(TEntity entity)
        {
            base.Entry(entity).State = EntityState.Modified;
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
