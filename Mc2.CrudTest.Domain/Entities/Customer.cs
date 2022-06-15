using Mc2.CrudTest.Domain.Common;
using PhoneNumbers;

namespace Mc2.CrudTest.Domain.Entities
{
    public class Customer : BaseEntity
    {
        #region Properties
        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public string DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string BankAccountNumber { get; private set; }

        #endregion
        #region Constructor
        private Customer()
        {

        }
        public Customer(string firstname, string lastname,
            string dateOfBirth, string phoneNumber, string email, string bankAccountNumber) : this()
        {
            CheckFirstNameNotNull(firstname);
            CheckLastNameNotNull(lastname);
            CheckDateTimeNotNull(dateOfBirth);
            CheckPhoneNumberRules(phoneNumber);
            CheckNotNullEmail(email);
            CheckBankAccountNumberRules(bankAccountNumber);
        }
        #endregion
        #region Methods
        private void CheckFirstNameNotNull(string firstName)
        {
            if (firstName is null)
                throw new NullReferenceException();
            Firstname = firstName;
        }
        private void CheckLastNameNotNull(string lastName)
        {
            if (lastName is null)
                throw new NullReferenceException();
            Lastname = lastName;
        }
        private void CheckDateTimeNotNull(string dateOfBirthDay)
        {
            if (dateOfBirthDay is null)
                throw new NullReferenceException();

            DateOfBirth = dateOfBirthDay;
        }
        private void CheckPhoneNumberRules(string phoneNumber)
        {
            if (phoneNumber is null)
                throw new NullReferenceException();
            if (phoneNumber.Length > 15)
                throw new ArgumentOutOfRangeException();
            PhoneNumber = phoneNumber;
        }
        private void CheckBankAccountNumberRules(string bankAccountNumber)
        {
            if (bankAccountNumber is null)
                throw new NullReferenceException();
            if (bankAccountNumber.Length > 30)
                throw new ArgumentOutOfRangeException();
            BankAccountNumber = bankAccountNumber;
        }
        private void CheckNotNullEmail(string email)
        {
            if (email is null)
                throw new NullReferenceException();
            Email = email;
        }
        public Customer AddNewValues(string firstname, string lastname,
            string dateOfBirth, string phoneNumber, string email, string bankAccountNumber)
        {
            CheckFirstNameNotNull(firstname);
            CheckLastNameNotNull(lastname);
            CheckDateTimeNotNull(dateOfBirth);
            CheckPhoneNumberRules(phoneNumber);
            CheckNotNullEmail(email);
            CheckBankAccountNumberRules(bankAccountNumber);
            return this;
        }
        #endregion
    }
}
