namespace Mc2.CrudTest.Api.Contracts.Customers.Responses
{
    //perform value comparison unlike classes that perform reference comparison when you compare them.
    public record CustomerResponse
    {
        public long Id { get; set; }
        public string Firstname { get; set; } = String.Empty;
        public string Lastname { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Email { get; set; } = String.Empty;
        public string BankAccountNumber { get; set; } = String.Empty;
    }
}
