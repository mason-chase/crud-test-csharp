using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Queries;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Models;
using MediatR;

namespace CleanArchitecture.Application.Handler;

public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
{
    private readonly ICustomerRepository _repository;
    public GetCustomerByIdHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }
    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        Customer customer = await _repository.GetById(request.Id);
        return customer;
    }
}
