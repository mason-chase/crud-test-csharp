using System;

namespace Mc2.CrudTest.AcceptanceTests.Contracts.Customers.Responses
{
    //perform value comparison unlike classes that perform reference comparison when you compare them.
    public record CustomerResponse
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
