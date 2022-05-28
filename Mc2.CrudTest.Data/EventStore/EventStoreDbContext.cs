using EventStore.ClientAPI;
using System.Net;

namespace Mc2.CrudTest.Data.EventStore;

public class EventStoreDbContext : IEventStoreDbContext
{
    public async Task<IEventStoreConnection> GetConnection()
    {
        IEventStoreConnection connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113), nameof(Data));

        await connection.ConnectAsync();

        return connection;
    }

    public async Task AppendToStreamAsync(params EventData[] events)
    {
        const string appName = nameof(Data);
        
        IEventStoreConnection connection = await GetConnection();

        await connection.AppendToStreamAsync(appName, ExpectedVersion.Any, events);
    }
}