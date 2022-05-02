using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

namespace Mc2.CrudTest.TestTools.Database
{
    public interface IInMemoryDatabase<TDbContext>
    {
        void GetContext(Action<TDbContext> context);
        TService InjectContext<TService>(Func<TDbContext, TService> context);
        int Manipulate(Action<TDbContext> context);
    }

    public class InMemoryDbContext<TDbContext>
        : IInMemoryDatabase<TDbContext> where TDbContext : DbContext
    {
        public static IInMemoryDatabase<TDbContext> CreateDatabase(Func<DbContextOptions<TDbContext>, TDbContext> factory)
        {
            var dbConnection = new SqliteConnection("DataSource=:memory:");
            dbConnection.Open();

            var options = new DbContextOptionsBuilder<TDbContext>().UseSqlite(dbConnection).Options;
            Func<TDbContext> createContext = () => factory(options);
            var dbContext = new InMemoryDbContext<TDbContext>(createContext);

            dbContext.InitDb();

            return dbContext;
        }

        protected virtual void InitDb()
        {
            using (var db = factory())
            {
                db.Database.EnsureCreated();
            }
        }

        private readonly Func<TDbContext> factory;
        protected InMemoryDbContext(Func<TDbContext> factory)
        {
            this.factory = factory;
        }

        public void GetContext(Action<TDbContext> context)
        {
            context(factory());
        }
        public TService InjectContext<TService>(Func<TDbContext, TService> createService)
        {
            return createService(factory());
        }
        public int Manipulate(Action<TDbContext> manipulate)
        {
            using (var db = factory())
            {
                manipulate(db);
                return db.SaveChanges();
            }
        }
    }
}
