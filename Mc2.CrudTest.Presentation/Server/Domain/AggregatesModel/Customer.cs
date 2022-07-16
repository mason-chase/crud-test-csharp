using System;

namespace Domain
{
    public class Customer
    : Entity, IAggregateRoot, IValidatebleObject
    {
        public string IdentityGuid { get; private set; }
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTimeOffset DateOfBirth { get; private set; }
        public ulong PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string BankAccountNumber { get; private set; }

        public Customer(string identity, string firstName, string lastname, DateTimeOffset dateOfBirth, string phoneNumber, string email, string bankAccountNumber) : this()
        {
            IdentityGuid = !string.IsNullOrWhiteSpace(identity) ? identity : throw new ArgumentNullException(nameof(identity));
            Firstname = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            Firstname = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            Firstname = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            Firstname = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            Firstname = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            Firstname = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            Firstname = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
        }

    }
}