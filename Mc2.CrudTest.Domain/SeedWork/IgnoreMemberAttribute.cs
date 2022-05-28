namespace Mc2.CrudTest.Domain.SeedWork;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class IgnoreMemberAttribute : Attribute
{
}