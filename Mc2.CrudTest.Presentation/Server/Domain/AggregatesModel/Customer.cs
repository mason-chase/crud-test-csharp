using Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
        public string Email { get; private set; }
        public string BankAccountNumber { get; private set; }

        public Customer(string identity, string firstName, string lastName, DateTimeOffset dateOfBirth, string phoneNumber, string email, string bankAccountNumber) : this()
        {

            IdentityGuid = !string.IsNullOrWhiteSpace(identity) ? identity : throw new ArgumentNullException(nameof(identity));
            Firstname = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            Lastname = !string.IsNullOrWhiteSpace(lastName) ? firstName : throw new ArgumentNullException(nameof(lastName));
            DateOfBirth = dateOfBirth;
            PhoneNumber = ValidatePhoneNumber(phoneNumber) ? phoneNumber : throw new ArgumentException(nameof(phoneNumber));
            System.Net.Mail.MailAddress.TryCreate(email, out var emailAddress);
            Email = !string.IsNullOrWhiteSpace(emailAddress?.Address) ? emailAddress.Address : throw new ArgumentException(nameof(email));
            BankAccountNumber = ValidateBankAccount(bankAccountNumber) ? bankAccountNumber : throw new ArgumentException(nameof(bankAccountNumber));
        }

        public Customer()
        {
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
            try
            {
                var fn = phoneNumberUtil.Parse(phoneNumber, null);

                var numberType = phoneNumberUtil.GetNumberType(fn);
                return numberType == PhoneNumbers.PhoneNumberType.MOBILE;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool ValidateBankAccount(string bankAccount)
        {
            var test = Regex.IsMatch(bankAccount, "((\\d{4})-){3}\\d{4}");
            return test;
        }
    }
}