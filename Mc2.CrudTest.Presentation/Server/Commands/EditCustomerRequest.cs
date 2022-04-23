using Mc2.CrudTest.DataLayer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Commands
{
    public class EditCustomerRequest : IRequest<Customer>
    {
        [Key]
        public string FirstName { get; set; }
        [Key]
        public string LastName { get; set; }
        [Key]
        public DateTime DateOfBirth { get; set; }
        [Phone(ErrorMessage = "Please enter a valid mobile number")]
        public string PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Please enter the correct email")]
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public bool IsDelete { get; set; }
    }
}
