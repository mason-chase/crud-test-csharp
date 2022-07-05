using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        private ISender _mediator = null!;

        protected ISender Mediator =>
            _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}