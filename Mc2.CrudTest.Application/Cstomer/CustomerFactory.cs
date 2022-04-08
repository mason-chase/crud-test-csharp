using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Model;

namespace Mc2.CrudTest.Application;

public sealed class CustomerFactory : ICustomerFactory
{
    public Customer Create(CustomerModel model)
    {
        return new Customer
        (
            new Name(model.FirstName, model.LastName, model.DateOfBirth),
            new Email(model.Email),
            model.BankAccountNumber,
            model.PhoneNumber

        );
    }
}
