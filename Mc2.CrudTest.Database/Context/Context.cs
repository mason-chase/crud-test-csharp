using Mc2.CrudTests.Database;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Database;

public sealed class Context : DbContext
{
    public Context(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly).Seed();
    }
}
