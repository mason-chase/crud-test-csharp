namespace Mc2.CrudTest.Domain.SeedWork;

public class DomainEventBase : IDomainEvent
{
    public DomainEventBase() => OccurredOn = DateTime.Now;

    public DateTime OccurredOn { get; }
}