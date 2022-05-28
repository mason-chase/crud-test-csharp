using AutoMapper;
using Mc2.CrudTest.Domain.DTO;
using Mc2.CrudTest.Services.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Bootstrapper.Handlers.Queries;

public class GetCustomerByIdQuery : IRequest<CustomerDTO>
{
    public Guid CustomerId { get; }

    public GetCustomerByIdQuery(Guid customerId) => CustomerId = customerId;
}

public class GetNinjaByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDTO>
{
    public GetNinjaByIdQueryHandler(ICustomerService customerService!!, IMapper mapper!!)
    {
        CustomerService = customerService;
        Mapper = mapper;
    }

    public ICustomerService CustomerService { get; }
    public IMapper Mapper { get; }

    public async Task<CustomerDTO> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var entitiy = await CustomerService.GetByIdAsync(cancellationToken, request.CustomerId);

        var customer = Mapper.Map<CustomerDTO>(entitiy);

        return customer;
    }
}