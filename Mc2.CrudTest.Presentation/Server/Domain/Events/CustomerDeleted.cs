using MediatR;

namespace Domain.Events
{
    public record CustomerDeletedEvent : IntegrationEvent, INotification
    {
        public CustomerDeletedEvent(int identity)
        {
            Identity = identity;
        }

        public int Identity { get; }
    }
}