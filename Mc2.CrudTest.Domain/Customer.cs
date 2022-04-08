using DotNetCore.Domain;
using System;

namespace Mc2.CrudTest.Domain;

public class Customer : Entity<long>
{
    public Customer
    (
        Name name,
        Email email,
        string bankAccountNumber,
        string phoneNumber
    )
    {
        Name = name;
        Email = email;
        BankAccountNumber = bankAccountNumber;
        PhoneNumber = phoneNumber;  
    }

    public Customer(long id) => Id = id;
    public Name Name { get; private set; }
    public string PhoneNumber { get; private set; }
    public Email Email { get; private set; }
    public string BankAccountNumber { get; private set; }

    public void Update(string firstName, string lastName, DateTime dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
    {
        Name = new Name(firstName, lastName,dateOfBirth);
        Email = new Email(email);
        BankAccountNumber = bankAccountNumber;
        PhoneNumber = phoneNumber;
    }
}
