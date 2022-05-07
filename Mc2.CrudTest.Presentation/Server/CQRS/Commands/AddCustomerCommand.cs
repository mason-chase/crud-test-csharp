using System;
using Mc2.CrudTest.Domain.DTO;
using Mc2.CrudTest.Presentation.Server.Models;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.CQRS.Commands
{
    public class AddCustomerCommand: IRequest<Customer>
    {
        public CustomerDTO CustomerDto { get; set; }

        public AddCustomerCommand(CustomerDTO dto)
        {
            CustomerDto = dto;
        }
    }
}
