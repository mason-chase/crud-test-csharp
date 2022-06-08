using CleanArchitecture.Domain.Models;
using MediatR;

namespace CleanArchitecture.Application.Queries;

public class GetCustomerByIdQuery : IRequest<Customer>
{
    public int Id { get; }

    public GetCustomerByIdQuery(int id)
    {
        Id = id;
    }
}
