using Mc2.CrudTest.Customers;
using Mc2.CrudTest.Customers.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICustomerService _customerService;
        public CustomerController(ILogger<WeatherForecastController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<GetCustomersOutput> GetCustomers([FromBody] GetCustomersInput input)
        {
            _logger.LogDebug($"GetCustomers");
            var result = await _customerService.GetCustomers(input);
            return result;
        }

        [HttpGet]
        public async Task<GetCustomerOutput> GetCustomer([FromBody] GetCustomerInput input)
        {
            _logger.LogDebug($"GetCustomer");
            var result = await _customerService.GetCustomer(input);
            return result;
        }

        [HttpPost]
        public async Task<UpsertCustomerOutput> UpsertCustomer([FromBody] UpsertCustomerInput input)
        {
            _logger.LogDebug($"UpsertCustomer");
            var result = await _customerService.UpsertCustomer(input);
            return result;
        }

        [HttpDelete]
        public async Task<DeleteCustomerOutput> DeleteCustomer([FromBody] DeleteCustomerInput input)
        {
            _logger.LogDebug($"DeleteCustomer");
            var result = await _customerService.DeleteCustomer(input);
            return result;
        }

    }
}
