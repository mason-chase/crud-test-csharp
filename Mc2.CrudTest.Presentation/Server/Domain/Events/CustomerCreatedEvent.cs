using MediatR;

namespace Domain.Events
{
    public class CustomerCreatedEvent : INotification
    {
        public CustomerCreatedEvent(string identity, string name, string email)
        {
            Identity = identity;
            Name = name;
            Email = email;
        }

        public string Identity { get; }
        public string Name { get; }
        public string Email { get; }
    }
}