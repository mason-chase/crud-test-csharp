namespace Mc2.CrudTest.Domain.SeedWork;

public interface IBusinessRule
{
    bool IsBroken();

    string Message { get; }
}