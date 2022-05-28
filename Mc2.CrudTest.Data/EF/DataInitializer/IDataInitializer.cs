namespace Mc2.CrudTest.Data.EF.DataInitializer;

public interface IDataInitializer
{
    ValueTask InitializeDataAsync(CancellationToken cancellationToken = default);
}
