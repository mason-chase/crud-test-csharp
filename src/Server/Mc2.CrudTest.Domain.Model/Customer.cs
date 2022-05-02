using Mc2.CrudTest.Domain.Model.ValueObject;
using System;

namespace Mc2.CrudTest.Domain.Model
{
	public class Customer
    {

		Customer() {}
		private Customer(Guid id, Name name, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
		{
			Id = id;
			Name = name;
			DateOfBirth = dateOfBirth;
			PhoneNumber = phoneNumber;
			Email = email;
			BankAccountNumber = bankAccountNumber;
			
		}

		public Guid Id { get; private set; }
		public Name Name { get; private set; }
		public DateTime DateOfBirth { get; private set; }
		public PhoneNumber PhoneNumber { get; private set; }
		public Email Email { get; private set; }
		public BankAccountNumber BankAccountNumber { get; private set; }


		public static Customer Create(Guid id, Name name, DateTime dateOfBirth,
			PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
		{
			return new Customer(id, name, dateOfBirth, phoneNumber, email, bankAccountNumber);
		}


		public void Edit(Name name, DateTime dateOfBirth, PhoneNumber phoneNumber, Email email, BankAccountNumber bankAccountNumber)
		{
            Name = name;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }
	}
}
