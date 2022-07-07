using Mc2.CrudTest.Domain.Models.Entities;
using MediatR;
using System;

namespace c2.CrudTest.Application.Commands
{
    public class UpdateCustomerCommand : IRequest<CustomerEntity>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ulong PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }

    }
}
