using Mc2.CrudTest.Customers;
using Mc2.CrudTest.Customers.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<GetCustomersOutput> GetCustomers(GetCustomersInput input)
        {
            return await _customerService.GetCustomers(input);
        }
    }
}
