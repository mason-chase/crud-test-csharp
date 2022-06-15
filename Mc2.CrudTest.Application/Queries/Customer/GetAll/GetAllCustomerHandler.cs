using Mc2.CrudTest.Application.Common.Interfaces.Repository;
using Mc2.CrudTest.Domain.DomainService.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.Queries.Customer.GetAll
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, List<Mc2.CrudTest.Domain.Entities.Customer>>
    {
        private readonly IBaseRepository<Mc2.CrudTest.Domain.Entities.Customer> _baseRepository;
        public GetAllCustomerHandler(IBaseRepository<Domain.Entities.Customer> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<List<Domain.Entities.Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var listOfRecords = _baseRepository.GetAll();

            return await Task.FromResult(listOfRecords);
        }
    }
}
