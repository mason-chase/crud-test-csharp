using AutoMapper;
using Mc2.CrudTest.Domain.DTO;
using Mc2.CrudTest.Services.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Bootstrapper.Handlers.Queries;

public class GetAllCustomerQuery : IRequest<IEnumerable<CustomerDTO>>
{
}

public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, IEnumerable<CustomerDTO>>
{
    public GetAllCustomerQueryHandler(ICustomerService customerService!!, IMapper mapper!!)
    {
        CustomerService = customerService;
        Mapper = mapper;
    }

    public ICustomerService CustomerService { get; }
    public IMapper Mapper { get; }

    public async Task<IEnumerable<CustomerDTO>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
    {
        var entities = await CustomerService.GetAllAsync(cancellationToken);

        var customers = Mapper.Map<IEnumerable<CustomerDTO>>(entities);

        return customers;
    }
}