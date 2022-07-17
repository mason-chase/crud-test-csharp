using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Customer
    : Entity, IAggregateRoot
    {
        public string IdentityGuid { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTimeOffset DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; }
        [EmailAddress]
        public string Email { get; private set; }
        public ulong BankAccountNumber { get; private set; }

        public Customer(string identity, string firstName, string lastName, DateTimeOffset dateOfBirth, string phoneNumber, string email, ulong bankAccountNumber) : this()
        {
            IdentityGuid = !string.IsNullOrWhiteSpace(identity) ? identity : throw new ArgumentNullException(nameof(identity));
            Firstname = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            Lastname = !string.IsNullOrWhiteSpace(lastName) ? firstName : throw new ArgumentNullException(nameof(lastName));
            DateOfBirth = dateOfBirth;
            PhoneNumber = Validate(phoneNumber) ? phoneNumber : throw new ArgumentException(nameof(phoneNumber));
            Email = !string.IsNullOrWhiteSpace(email) ? firstName : throw new ArgumentNullException(nameof(email));
            BankAccountNumber = bankAccountNumber;
        }

        private bool Validate(string phoneNumber)
        {
            return true;
        }
    }
}