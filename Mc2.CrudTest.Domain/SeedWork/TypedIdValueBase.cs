namespace Mc2.CrudTest.Domain.SeedWork;

public abstract class TypedIdValueBase : IEquatable<TypedIdValueBase>
{
    public Guid Value { get; }

    protected TypedIdValueBase(Guid value) => Value = value;

    public override bool Equals(object obj) =>
        ReferenceEquals(null, obj) ? false : obj is TypedIdValueBase other && Equals(other);

    public override int GetHashCode() => Value.GetHashCode();

    public bool Equals(TypedIdValueBase other) => Value == other.Value;

    public static bool operator ==(TypedIdValueBase obj1, TypedIdValueBase obj2)
    {
        if (Equals(obj1, null))
        {
            if (Equals(obj2, null)) return true;
            return false;
        }
        return obj1.Equals(obj2);
    }
    public static bool operator !=(TypedIdValueBase x, TypedIdValueBase y) => !(x == y);
}