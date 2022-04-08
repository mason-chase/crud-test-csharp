using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Model;
using System;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Database;

public static class CustomerExpression
{

    public static Expression<Func<Customer, CustomerModel>> Model => customer => new CustomerModel
    {
        Id = customer.Id,
        FirstName = customer.Name.FirstName,
        LastName = customer.Name.LastName,
        DateOfBirth = customer.Name.DateOfBirth,
        Email = customer.Email.Value,
        BankAccountNumber = customer.BankAccountNumber,
        PhoneNumber = customer.PhoneNumber
    };

    public static Expression<Func<Customer, bool>> Id(long id)
    {
        return customer => customer.Id == id;
    }
}
