using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Commands
{
    public class DeleteCustomerRequest : IRequest<bool>
    {
        public string FirstName { get; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DeleteCustomerRequest(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
    }
}
