using Domain;
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
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICustomerService _customerService;
        private readonly ICustomerQueries _customerQueries;
        public CustomerController(ICustomerService customerService, IMediator mediator, ICustomerQueries customerQueries)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _customerQueries = customerQueries ?? throw new ArgumentNullException(nameof(customerQueries));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

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



    }
}
