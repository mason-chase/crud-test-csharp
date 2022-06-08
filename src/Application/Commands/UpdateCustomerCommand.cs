using CleanArchitecture.Domain.Models;
using MediatR;

namespace CleanArchitecture.Application.Commands;

public class UpdateCustomerCommand : IRequest<bool>
{
    public Customer customer { get; set; }

    public UpdateCustomerCommand(Customer customer)
    {
        this.customer = customer;
    }
}
