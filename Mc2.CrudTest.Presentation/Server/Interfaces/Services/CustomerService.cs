using Mc2.CrudTest.Application.Commands.Customer.Create;
using Mc2.CrudTest.Application.Commands.Customer.Delete;
using Mc2.CrudTest.Application.Commands.Customer.Edit;
using Mc2.CrudTest.Application.Queries.Customer.GetAll;
using Mc2.CrudTest.Application.Queries.Customer.GetById;
using Mc2.CrudTest.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Interfaces.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMediator _mediator;
        public CustomerService(IMediator mediator)
        {
            _mediator = mediator;
        }


        public async Task<Guid> CreateAsync(CreateCustomerCommand dto)
            => await _mediator.Send(dto);

        public async Task<EditCustomerCommand> UpdateAsync(EditCustomerCommand dto)
            => await _mediator.Send(dto);

        public async Task DeleteAsync(DeleteCustomerCommand dto)
            => await _mediator.Send(dto);

        public async Task<List<Customer>> GetAllAsync(GetAllCustomerQuery dto)
            => await _mediator.Send(dto);

        public async Task<Customer> GetByIdAsync(GetCustomerByIdQuery dto)
            => await _mediator.Send(dto);
    }
}
