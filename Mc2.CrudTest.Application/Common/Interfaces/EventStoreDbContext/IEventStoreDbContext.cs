using EventStore.ClientAPI;

namespace Mc2.CrudTest.Application.Common.Interfaces.EventStoreDbContext
{
    public interface IEventStoreDbContext
    {
        Task<IEventStoreConnection> GetConnection();

        Task AppendToStreamAsync(params EventData[] events);
    }
}
