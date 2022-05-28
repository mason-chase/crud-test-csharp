using Mc2.CrudTest.Data.EF.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    private static string DataConnectionString => new DatabaseConfiguration().GetDataConnectionString();
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(DataConnectionString)
         //.UseSqlServer
         //(
         //    DataConnectionString,
         //        sqlOptions => sqlOptions
         //            .EnableRetryOnFailure(maxRetryCount: 4, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null)
         //            .MinBatchSize(4)
         //            .MaxBatchSize(31)
         //            .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
         //            .MigrationsAssembly(typeof(AppDbContext).GetTypeInfo().Assembly.GetName().Name)
         //            .MigrationsHistoryTable("MigrationsHistory", "Mc2")
         //            .UseNetTopologySuite()
         //            .UseRelationalNulls()
         ////.UseQuerySplittingBehavior()
         ////.UseRowNumberForPaging()
         //)
         ////.ConfigureWarnings(x => x.Throw(RelationalEventId.QueryClientEvaluationWarning))
         //.EnableSensitiveDataLogging()
         //.EnableDetailedErrors()
         //.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
         ////.UseLazyLoadingProxies()
         ;

        return new AppDbContext(optionsBuilder.Options);
    }
}
