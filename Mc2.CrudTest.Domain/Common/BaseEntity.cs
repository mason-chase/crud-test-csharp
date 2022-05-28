namespace Mc2.CrudTest.Domain.Common;

public abstract class BaseEntity<T>
{
    public virtual T Id { get; set; }
}