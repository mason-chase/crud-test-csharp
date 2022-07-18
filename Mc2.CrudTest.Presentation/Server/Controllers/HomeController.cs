using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet()]
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
