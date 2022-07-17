using MediatR;

namespace Domain.Events
{
    public record CustomerDeletedEvent : IntegrationEvent, INotification
    {
        public CustomerDeletedEvent(string identity)
        {
            Identity = identity;
        }

        public string Identity { get; }
    }
}