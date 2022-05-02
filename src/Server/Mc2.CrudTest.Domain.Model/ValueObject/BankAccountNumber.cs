using Mc2.CrudTest.Domain.Model.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Domain.Model.ValueObject
{
    public class BankAccountNumber
    {
        BankAccountNumber() { }
        private BankAccountNumber(string value)
        {
            IsValid(value);

            Value = value;
        }

        public string Value { get; private set; }

        public new static BankAccountNumber Create(string value)
            => new BankAccountNumber(value);

        public static implicit operator BankAccountNumber(string value)
            => value is null ? null : Create(value);

        public static implicit operator string(BankAccountNumber email)
            => email?.Value;

        private void IsValid(string accountNumber)
        {          
            bool isMatch = Regex.IsMatch(accountNumber, "^[0-9]*$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

            if (!isMatch)
            {
                throw new InvalidBankAccountNumberException();
            }
        }
    }
}
