using Mc2.CrudTest.Application.Customers;
using Mc2.CrudTest.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    public class CustomerController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            return HandleResult(await Mediator.Send(new Detail.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Customer = customer }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCustomer(Guid id, Customer customer)
        {
            customer.Id = id;

            return HandleResult(await Mediator.Send(new Update.Command { Customer = customer }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
