using Mc2.CrudTest.Domain.Model.Exceptions;
using System;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Domain.Model.ValueObject
{
    public class Email
    {
        Email() { }
        private Email(string value)
        {
            IsValid(value);

            Value = value;
        }

        public string Value { get; private set; }

        public new static Email Create(string value)
            => new Email(value);

        public static implicit operator Email(string value)
            => value is null ? null : Create(value);

        public static implicit operator string(Email email)
            => email?.Value;

        private void IsValid(string email)
        {
            bool isMatch = Regex.IsMatch(email,
                    @"^[_A-Za-z0-9-\+]+(\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\.[A-Za-z0-9-]+)*(\.[A-Za-z]{2,4})$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

            if(!isMatch)
            {
                throw new InvalidCustomerEmailException();
            }
        }
    }
}
