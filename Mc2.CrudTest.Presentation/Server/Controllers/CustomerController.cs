using Application.Api.Commands;
using Domain;
using Mc2.CrudTest.Presentation.Server.Commands;
using Mc2.CrudTest.Presentation.Server.Queries;
using Mc2.CrudTest.Presentation.Server.Services.Abstract;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        //private readonly ICustomerService _customerService;
        private readonly ICustomerQueries _customerQueries;
        public CustomerController( IMediator mediator, ICustomerQueries customerQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _customerQueries = customerQueries ?? throw new ArgumentNullException(nameof(customerQueries));
          //  _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [Route("{customerId:int}")]
        [HttpGet]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetCustomerAsync(int customerId)
        {
            try
            {
                var customer = await _customerQueries.GetCustomerAsync(customerId);

                return Ok(customer);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Customer>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomersAsync()
        {
            var customers = await _customerQueries.GetAllCustomersAsync();

            return Ok(customers);

        }

        [Route("create")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateCustomerCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var userCreate = new IdentifiedCommand<CreateCustomerCommand, bool>(command, guid);

                commandResult = await _mediator.Send(userCreate);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Route("delete")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteCustomerAsync([FromBody] DeleteCustomerCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool commandResult = false;

            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var userDelete = new IdentifiedCommand<DeleteCustomerCommand, bool>(command, guid);

                commandResult = await _mediator.Send(userDelete);
            }

            if (!commandResult)
            {
                return BadRequest();
            }

            return Ok();
        }


    }
}
