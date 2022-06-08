using CleanArchitecture.Domain.DTO;
using CleanArchitecture.Domain.Models;
using MediatR;

namespace CleanArchitecture.Application.Commands;

public class AddCustomerCommand : IRequest<Customer>
{
    public CustomerDTO CustomerDto { get; set; }

    public AddCustomerCommand(CustomerDTO dto)
    {
        CustomerDto = dto;
    }
}
