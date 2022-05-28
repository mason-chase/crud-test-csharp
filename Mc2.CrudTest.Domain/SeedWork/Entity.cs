namespace Mc2.CrudTest.Domain.SeedWork;

public abstract class Entity
{
    private List<IDomainEvent> _domainEvents;

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents = _domainEvents ?? new List<IDomainEvent>();
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents() => _domainEvents?.Clear();

    protected static void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
            throw new BusinessRuleValidationException(rule);
    }
}
