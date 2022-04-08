using Mc2.CrudTest.Application;
using Mc2.CrudTest.Model;
using Microsoft.AspNetCore.Mvc;
using DotNetCore.AspNetCore;
using DotNetCore.Objects;

namespace Mc2.CrudTest.Presentation.Server.Controllers;

[ApiController]
[Route("customers")]
public sealed class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService) => _customerService = customerService;

    [HttpPost]
    public IActionResult Add(CustomerModel model) => _customerService.AddAsync(model).ApiResult();

    [HttpDelete("{id}")]
    public IActionResult Delete(long id) => _customerService.DeleteAsync(id).ApiResult();

    [HttpGet("{id}")]
    public IActionResult Get(long id) => _customerService.GetAsync(id).ApiResult();

    [HttpGet("grid")]
    public IActionResult Grid([FromQuery] GridParameters parameters) => _customerService.GridAsync(parameters).ApiResult();

    [HttpGet]
    public IActionResult List() => _customerService.ListAsync().ApiResult();

    [HttpPut("{id}")]
    public IActionResult Update(CustomerModel model) => _customerService.UpdateAsync(model).ApiResult();
}

