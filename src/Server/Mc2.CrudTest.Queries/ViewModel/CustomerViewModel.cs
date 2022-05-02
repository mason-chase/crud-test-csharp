using System;

namespace Mc2.CrudTest.Queries.ViewModel
{
    public class CustomerViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
