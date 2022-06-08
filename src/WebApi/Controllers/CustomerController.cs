using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Domain.DTO;
using CleanArchitecture.Domain.Exceptions;
using CleanArchitecture.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ISender _mediatr;
    public CustomerController(ISender mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet]
    public async Task<ActionResult> GetList()
    {
        try
        {
            List<Customer> customers = await _mediatr.Send(new GetAllCustomerQuery());
            return Ok(customers);
        }
        catch (Exception)
        {
            return BadRequest("Internal Server Error");
        }
    }

    [HttpGet("GetCustomer/{Id}")]
    public async Task<ActionResult> GetById(int Id)
    {
        try
        {
            Customer customer = await _mediatr.Send(new GetCustomerByIdQuery(Id));
            return customer != null ? Ok(customer) : NoContent();
        }
        catch (Exception)
        {
            return BadRequest("Internal Server Error");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CustomerDTO dto)
    {
        try
        {
            Customer customer = await _mediatr.Send(new AddCustomerCommand(dto));
            return customer != null
                ? Ok(customer)
                : BadRequest(new { Message = "First Name , Email or BirthDate Should be Unique" });
        }
        catch (NotValidBankAccountNumber)
        {
            return BadRequest(new { ErrorMessage = "Bank Account Number Is Not Valid!" });
        }
        catch (NotValidEmail)
        {
            return BadRequest(new { ErrorMessage = "Email Is Not Valid!" });
        }
        catch (NotValidPhoneNumber)
        {
            return BadRequest(new { ErrorMessage = "Phone Number Is Not Valid!" });
        }
        catch (Exception)
        {
            return BadRequest("Internal Server Error");
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] Customer customer)
    {
        try
        {
            bool result = await _mediatr.Send(new UpdateCustomerCommand(customer));
            return result
                ? Ok("Success")
                : BadRequest(new { Message = "First Name , Email or BirthDate Should be Unique" });
        }
        catch (NotValidBankAccountNumber)
        {
            return BadRequest(new { ErrorMessage = "Bank Account Number Is Not Valid!" });
        }
        catch (NotValidPhoneNumber)
        {
            return BadRequest(new { ErrorMessage = "Phone Number Is Not Valid!" });
        }
        catch (NotValidEmail)
        {
            return BadRequest(new { ErrorMessage = "Email Is Not Valid!" });
        }
        catch (Exception)
        {
            return BadRequest("Internal Server Error");
        }
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            bool result = await _mediatr.Send(new DeleteCustomerCommand(id));
            return result ? Ok("Success") : NotFound();
        }
        catch (Exception)
        {
            return BadRequest("Internal Server Error");
        }
    }

}
