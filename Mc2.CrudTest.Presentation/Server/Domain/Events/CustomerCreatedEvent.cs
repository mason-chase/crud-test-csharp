using Mc2.CrudTest.Presentation.Server.Domain.Events;
using MediatR;

namespace Domain.Events
{
    public record CustomerCreatedEvent : IntegrationEvent, INotification
    {

        public CustomerCreatedEvent(Customer customer)
        {
            Customer = customer;
        }

        public Customer Customer { get; }

    }
}