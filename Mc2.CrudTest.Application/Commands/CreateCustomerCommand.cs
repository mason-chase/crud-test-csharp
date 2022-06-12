using MediatR;
using System;

namespace c2.CrudTest.Application.Commands
{
    public class CreateCustomerCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

    }
}
