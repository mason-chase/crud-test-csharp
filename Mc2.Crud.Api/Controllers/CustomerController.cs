using Mc2.CrudTest.Api.Contracts.Customers;
using Mc2.CrudTest.Api.Contracts.Customers.Requests;
using Mc2.CrudTest.Api.Contracts.Customers.Responses;
using Mc2.CrudTest.Application.Customers.CommandHandlers;
using Mc2.CrudTest.Application.Customers.QueryHandlers;
using Mc2.CrudTest.DataAccess;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly DataContext _dataContext;
        public CustomerController(DbContextOptions dbOptions)
        {
            _dataContext = new DataContext(dbOptions);
        }

        //To Do: add model validation with [ValidationModel] attrebute.
        //To Do: Add exception filter to api.

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            GetCustomerByIdQueryHandler handler;
            var query = new GetCustomerById { CustomerId = id };

            handler = new GetCustomerByIdQueryHandler(_dataContext);
            var response = await handler.Handle(query);
            if (response is null) return NotFound($" no customer with id {id} found!");
            var customer = CustomerMappings.MapToResponse(response);
            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllCustomersQueryHandler handler;
            List<CustomerResponse> customerReponses = new List<CustomerResponse>();
            var query = new GetAllCustomers();

            handler = new GetAllCustomersQueryHandler(_dataContext);
            var response = await handler.Handle(query);
            response.ToList().ForEach(c => { customerReponses.Add(CustomerMappings.MapToResponse(c)); });

            return Ok(customerReponses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreate customer)
        {
            CreateCustomerCommandHandler handler;

            var request = CustomerMappings.MapToCommand(customer);
            handler = new CreateCustomerCommandHandler(_dataContext);
            var response = await handler.Handle(request);
            var customerReponse = CustomerMappings.MapToResponse(response);
            return CreatedAtAction(nameof(GetById), new { id = response.Id }, customerReponse);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCustomer(long id, CustomerCreate updatedCustomer)
        {
            UpdateCustomerCommandHandler handler;

            var command = CustomerMappings.MapToUpdateCommand(updatedCustomer);
            command.Id = id;
            handler = new UpdateCustomerCommandHandler(_dataContext);
            var response = await handler.Handle(command);
            if (response is null) return NotFound();
            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            DeleteCustomerCommandHandler handler;

            var command = new DeleteCustomerCommand { Id = id };
            handler = new DeleteCustomerCommandHandler(_dataContext);
            await handler.Handle(command);
            return NoContent();

        }
    }
}