using EventStore.ClientAPI;
using Mc2.CrudTest.Application.Common.Interfaces.EventStoreDbContext;
using System.Net;

namespace Mc2.CrudTest.Application.Common.Service
{
    public class EventStoreDbContext : IEventStoreDbContext
    {
        public async Task<IEventStoreConnection> GetConnection()
        {
            IEventStoreConnection connection = EventStoreConnection.Create(
                new IPEndPoint(IPAddress.Loopback, 1113),
                "Mc2CrudTest");

            await connection.ConnectAsync();

            return connection;
        }

        public async Task AppendToStreamAsync(params EventData[] events)
        {
            const string appName = "Mc2CrudTest";
            IEventStoreConnection connection = await GetConnection();

            await connection.AppendToStreamAsync(appName, ExpectedVersion.Any, events);
        }
    }
}
