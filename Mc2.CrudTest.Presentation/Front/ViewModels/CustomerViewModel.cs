using System;

namespace Mc2.CrudTest.Presentation.Front.ViewModels
{
    public class CustomerViewModel
    {
        public string IdentityGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
