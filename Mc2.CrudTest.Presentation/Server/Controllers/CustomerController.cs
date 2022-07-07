using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using c2.CrudTest.Application.Commands;
using c2.CrudTest.Application.Queries;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        [Route("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await Mediator.Send(new GetAllCustomersQuery()));
        }

        [HttpGet]
        [Route("GetCustomer")]
        public async Task<IActionResult> GetCustomerById(int customerId)
        {
            return Ok(await Mediator.Send(new GetCustomerByIdQuery { Id = customerId }));

        }

        [HttpPost]
        [Route("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(int customerId, UpdateCustomerCommand command)
        {
            if (customerId != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            return Ok(await Mediator.Send(new DeleteCustomerByIdCommand { Id = customerId }));
        }

    }
}
