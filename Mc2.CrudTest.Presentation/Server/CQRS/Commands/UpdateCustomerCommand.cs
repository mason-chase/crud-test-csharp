using System;
using Mc2.CrudTest.Domain.DTO;
using Mc2.CrudTest.Presentation.Server.Models;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.CQRS.Commands
{
    public class UpdateCustomerCommand: IRequest<bool>
    {
        public Customer customer { get; set; }

        public UpdateCustomerCommand(Customer customer)
        {
            this.customer = customer;
        }
    }
}
