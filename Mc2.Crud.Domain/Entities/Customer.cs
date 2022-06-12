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
            //To Do: add validations here.

            return new Customer
            {
                Id = id,
                Firstname = firstName,
                Lastname = lastname,
                DateOfBirth = dateOfBirth,
                PhoneNumber = phoneNumber,
                Email = email,
                BankAccountNumber = BankAccountNumber
            };
        }

        public void UpdateCustomer(Customer customer)
        {
            //To Do: add validation here.

        }
    }
}