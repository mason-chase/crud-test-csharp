using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Mc2.CrudTest.Application.Administration.Customers.Queries;
using Mc2.CrudTest.Application.Administration.Customers.Commands;

namespace Mc2.CrudTest.WebApi.Controllers
{
    public class CustomersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetCustomersQuery request)
        {
            var result = await Mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetCustomerQuery request)
        {
            var result = await Mediator.Send(request);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand request)
        {
            if (ModelState.IsValid)
            {
                var userId = await Mediator.Send(request);

                return Ok(userId);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCustomerCommand request)
        {
            if (ModelState.IsValid)
            {
                var userId = await Mediator.Send(request);

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCustomerCommand request)
        {
            if (ModelState.IsValid)
            {
                var userId = await Mediator.Send(request);

                return Ok();
            }

            return BadRequest();
        }
    }
}