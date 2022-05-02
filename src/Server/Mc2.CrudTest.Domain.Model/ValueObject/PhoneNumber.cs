using Mc2.CrudTest.Domain.Model.Exceptions;
using PhoneNumbers;

namespace Mc2.CrudTest.Domain.Model.ValueObject
{
    public class PhoneNumber
    {
        PhoneNumber() { }
        private PhoneNumber(string countryCode, string number)
        {
            IsValid(countryCode, number);

            CountryCode = countryCode;
            Number = number;
        }

        public string CountryCode { get; private set; }
        public string Number { get; private set; }

        public new static PhoneNumber Create(string countryCode, string number)
          => new PhoneNumber(countryCode, number);


        private void IsValid(string countryCode, string number)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                PhoneNumbers.PhoneNumber phoneNumber = phoneUtil.Parse(number, countryCode);
                bool isValidNumber = phoneUtil.IsValidNumber(phoneNumber);
                if (!isValidNumber)
                {
                    throw new InvalidPhonNumberException();
                }
            }
            catch (NumberParseException e)
            {
                throw new System.Exception(e.Message);
            }

        }
    }
}
