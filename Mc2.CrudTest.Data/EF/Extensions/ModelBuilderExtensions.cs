using Mc2.CrudTest.Data.EF.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Data.EF.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyAllConfigurationsForAppDbContext(this ModelBuilder modelBuilder)
    {
        //modelBuilder.HasDefaultSchema("Mc2");
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        //modelBuilder.ApplyAllConfigurationsForAppDbContext();
        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(AppDbContext)));
    }
}
