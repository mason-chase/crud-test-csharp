using EventStore.ClientAPI;

namespace Mc2.CrudTest.Data.EventStore;

public interface IEventStoreDbContext
{
    Task<IEventStoreConnection> GetConnection();

    Task AppendToStreamAsync(params EventData[] events);
}