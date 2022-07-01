using Mc2.CrudTest.Domain.Entities;
using MediatR;

namespace Mc2.CrudTest.Domain.Commands
{
    public class UpdateCustomerCommand : IRequest<Customer>
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
