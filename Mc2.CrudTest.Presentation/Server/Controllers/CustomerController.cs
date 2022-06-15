using Mc2.CrudTest.Application.Commands.Customer.Create;
using Mc2.CrudTest.Application.Commands.Customer.Delete;
using Mc2.CrudTest.Application.Commands.Customer.Edit;
using Mc2.CrudTest.Application.Queries.Customer.GetAll;
using Mc2.CrudTest.Application.Queries.Customer.GetById;
using Mc2.CrudTest.Presentation.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost("CreateCustomer")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateCustomerAsync(CreateCustomerCommand dto)
            => Ok(await _customerService.CreateAsync(dto));

        [HttpPut("EditCustomer")]
        [ProducesResponseType(typeof(EditCustomerCommand), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateCustomerAsync(EditCustomerCommand dto)
         => Ok(await _customerService.UpdateAsync(dto));

        [HttpDelete("DeleteCustomer")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCustomerAsync(DeleteCustomerCommand dto)
        {
            await _customerService.DeleteAsync(dto);
            return Ok();
        }
        [HttpGet("GetAllCustomer")]
        [ProducesResponseType(typeof(Mc2.CrudTest.Domain.Entities.Customer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCustomerAsync([FromQuery]GetAllCustomerQuery dto)
        {
            return Ok(await _customerService.GetAllAsync(dto));
        }
        [HttpGet("GetCustomerById")]
        [ProducesResponseType(typeof(Mc2.CrudTest.Domain.Entities.Customer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCustomerByIdAsync([FromQuery] GetCustomerByIdQuery dto)
        {
            return Ok(await _customerService.GetByIdAsync(dto));
        }

    }
}
