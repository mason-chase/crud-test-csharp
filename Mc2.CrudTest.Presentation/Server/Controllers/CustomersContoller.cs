using Mc2.CrudTest.Domain.Entities;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomersContoller : ControllerBase
    {
        public CustomersContoller(ICustomerService customerService!!) => CustomerService = customerService;

        public ICustomerService CustomerService { get; }

        [HttpGet("[Action]")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await CustomerService.GetAllAsync(cancellationToken);

            if (result.Any() is false) return NoContent();

            return Ok(result);
        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> AddAsync(
            [FromBody] Customer newCustomer,
            CancellationToken cancellationToken = default)
        {
            await CustomerService.AddAsync(newCustomer, cancellationToken, true);

            return Created(string.Empty, newCustomer);
        }
    }
}