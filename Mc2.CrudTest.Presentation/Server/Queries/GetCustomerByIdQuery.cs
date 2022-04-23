using Mc2.CrudTest.DataLayer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public string FirstName { get; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GetCustomerByIdQuery(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
    }
}
