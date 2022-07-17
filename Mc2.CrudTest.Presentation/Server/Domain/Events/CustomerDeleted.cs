using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Domain.Events
{
    public class CustomerCreatedEvent : INotification
    {
        public CustomerCreatedEvent(string identity)
        {
            Identity = identity;
        }

        public string Identity { get; }
    }
}