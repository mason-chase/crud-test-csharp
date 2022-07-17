using MediatR;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Domain
{
    public interface ICustomerIntegrationEventService
    {
        Task AddAndSaveEventAsync(INotification evt);
    }
}
