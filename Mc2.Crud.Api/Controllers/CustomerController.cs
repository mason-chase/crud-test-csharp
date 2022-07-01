using Mc2.CrudTest.Api.Contracts.Customers;
using Mc2.CrudTest.Api.Contracts.Customers.Requests;
using Mc2.CrudTest.Api.Contracts.Customers.Responses;
using Mc2.CrudTest.Application.Customers.CommandHandlers;
using Mc2.CrudTest.Application.Customers.QueryHandlers;
using Mc2.CrudTest.DataAccess;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Mc2.CrudTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator , DbContextOptions dbOptions)
        {
            _mediator = mediator;
        }

        //To Do: Add exception filter to api.

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var query = new GetCustomerById { CustomerId = id };
            var response = await _mediator.Send(query);
            if (response is null) return NotFound($" no customer with id {id} found!");
            var customer = CustomerMappings.MapToResponse(response);
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<CustomerResponse> customerReponses = new List<CustomerResponse>();
                var query = new GetAllCustomersQuery();
                var response = await _mediator.Send(query);
                response.ToList().ForEach(c => { customerReponses.Add(CustomerMappings.MapToResponse(c)); });
                return Ok(customerReponses);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreate customer)
        {
            var request = CustomerMappings.MapToCommand(customer);
            var response = await _mediator.Send(request);
            var customerReponse = CustomerMappings.MapToResponse(response);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, customerReponse);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCustomer(long id, CustomerCreate updatedCustomer)
        {
            var command = CustomerMappings.MapToUpdateCommand(updatedCustomer);
            command.Id = id;
            var response = await _mediator.Send(command);
            if (response is null) return NotFound();
            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();

        }
    }
}