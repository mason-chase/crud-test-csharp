using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mc2.CrudTest.DataLayer.Entities;
using Mc2.CrudTest.DataLayer.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return await _customerRepository.GetAllCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{email}")]
        public async Task<Customer> GetAsync(string email)
        {
            return await _customerRepository.GetCustomerByEmail(email);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Faild, Please cheack again input value");
            }
            var result = await _customerRepository.AddCustomer(customer);
            if (!result)
            {
                return BadRequest("Failed to add customer");
            }

            return Ok("Success to add customer");
        }

        // PUT api/<CustomerController>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Faild, Please cheack again input value");
            }
            var result = await _customerRepository.UpdateCustomer(customer);
            if (!result)
            {
                return BadRequest("Failed to update customer");
            }

            return Ok("Success to update customer");
        }

        // DELETE api/<CustomerController>/example@info.com
        [HttpDelete("{emailAddress}")]
        public async Task<IActionResult> DeleteAsync(string emailAddress)
        {
            var result = await _customerRepository.DeleteCustomer(emailAddress);
            if (!result)
            {
                return BadRequest("Failed to add customer");
            }

            return Ok("Success to add customer");
        }
    }
}
