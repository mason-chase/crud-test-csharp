using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Mc2.CrudTest.Database;

public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        const string connectionString = "Server=.;Database=CrudTst;Trusted_Connection=True;";

        return new Context(new DbContextOptionsBuilder<Context>().UseSqlServer(connectionString).Options);
    }
}
