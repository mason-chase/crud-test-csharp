using CleanArchitecture.Application.Queries;
using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Models;
using MediatR;

namespace CleanArchitecture.Application.Handler;

public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, List<Customer>>
{
    private readonly ICustomerRepository _repository;
    public GetAllCustomerQueryHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }
    public async Task<List<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        List<Customer> customers = await _repository.GetList();
        return customers;
    }
}
