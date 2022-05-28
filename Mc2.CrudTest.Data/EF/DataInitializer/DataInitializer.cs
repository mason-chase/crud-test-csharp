using Mc2.CrudTest.Data.EF.DatabaseContext;

namespace Mc2.CrudTest.Data.EF.DataInitializer;

public class DataInitializer : IDataInitializer
{
    public DataInitializer(AppDbContext appDbContext) =>
        AppDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));

    public AppDbContext AppDbContext { get; }

    public async ValueTask InitializeDataAsync(CancellationToken cancellationToken = default) =>
        await AppDbContext.Database.EnsureCreatedAsync(cancellationToken);
}