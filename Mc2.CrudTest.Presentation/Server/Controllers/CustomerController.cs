using Mc2.CrudTest.DataLayer.Entities;
using Mc2.CrudTest.Presentation.Server.Commands;
using Mc2.CrudTest.Presentation.Server.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var query = new GetAllCustomerQuery();
            var Result = await _mediator.Send(query);
            return Ok(Result);
        }

        [HttpGet("GetCustomer")]
        public async Task<IActionResult> GetCustomerById(string firstName, string lastName, DateTime dateOfBirth)
        {
            var request = new GetCustomerByIdQuery(firstName,lastName,dateOfBirth);
            var Result = await _mediator.Send(request);
            return Result != null ?  Ok(Result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest command) 
        {
            var Result = await _mediator.Send(command);
            return Result != null ? CreatedAtAction("GetAllCustomer", Result) : BadRequest(new { message = "Please enter the fields correctly" });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(string firstName, string lastName, DateTime dateOfBirth) 
        {
            var request = new DeleteCustomerRequest(firstName, lastName, dateOfBirth);
            var Result = await _mediator.Send(request);
            return Result ? Ok("Success") : NotFound();
        }

        [HttpPost("EditCustomer")]
        public async Task<IActionResult> EditCustomer([FromBody] EditCustomerRequest command) 
        {
            var Result = await _mediator.Send(command);
            return Result != null ? CreatedAtAction("GetAllCustomer", Result) : BadRequest(new { message = "Please enter the fields correctly" });
        }
    }
}
