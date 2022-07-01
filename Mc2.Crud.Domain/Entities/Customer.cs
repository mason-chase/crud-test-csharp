using Mc2.CrudTest.Domain.Exceptions;
using Mc2.CrudTest.Domain.Validators.CustomerValidators;

namespace Mc2.CrudTest.Domain.Entities
{
    public class Customer
    {
        public long Id { get; set; }
        public string Firstname { get; private set; } = String.Empty;
        public string Lastname { get; private set; } = String.Empty;
        public DateTime DateOfBirth { get; private set; }
        public ulong PhoneNumber { get; private set; }
        public string Email { get; private set; } = String.Empty;
        public string BankAccountNumber { get; private set; } = String.Empty;


        public static Customer CreateCustomer(long id, string firstName, string lastname, DateTime dateOfBirth,
            ulong phoneNumber, string email, string BankAccountNumber)
        {
            var validator = new CustomerValidator();
            var objectToValidate = new Customer
            {
                Id = id,
                Firstname = firstName,
                Lastname = lastname,
                DateOfBirth = dateOfBirth,
                PhoneNumber = phoneNumber,
                Email = email,
                BankAccountNumber = BankAccountNumber
            };
            var validationResult = validator.Validate(objectToValidate);
            if (validationResult.IsValid) return objectToValidate;
            var exception = new CustomerNotValidException("Customer is not valid !");
            foreach (var error in validationResult.Errors)
            {
                exception.ValidationErrors.Add(error.ErrorMessage);
            }
            throw exception;
        }

        public static Customer UpdateCustomer(long id, string firstName, string lastname, DateTime dateOfBirth,
            ulong phoneNumber, string email, string BankAccountNumber)
        {
            var validator = new CustomerValidator();
            var objectToValidate = new Customer
            {
                Id = id,
                Firstname = firstName,
                Lastname = lastname,
                DateOfBirth = dateOfBirth,
                PhoneNumber = phoneNumber,
                Email = email,
                BankAccountNumber = BankAccountNumber
            };
            var validationResult = validator.Validate(objectToValidate);
            if (validationResult.IsValid) return objectToValidate;
            var exception = new CustomerNotValidException("Customer is not valid !");
            foreach (var error in validationResult.Errors)
            {
                exception.ValidationErrors.Add(error.ErrorMessage);
            }
            throw exception;
        }
    }
}