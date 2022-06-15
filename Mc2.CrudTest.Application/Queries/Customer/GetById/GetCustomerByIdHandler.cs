using Mc2.CrudTest.Application.Common.Interfaces.Repository;
using MediatR;

namespace Mc2.CrudTest.Application.Queries.Customer.GetById
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Mc2.CrudTest.Domain.Entities.Customer>
    {
        private readonly IBaseRepository<Mc2.CrudTest.Domain.Entities.Customer> _baseRepository;
        public GetCustomerByIdHandler(IBaseRepository<Domain.Entities.Customer> baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<Domain.Entities.Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = _baseRepository.FindById(new Guid(request.Id));

            return await Task.FromResult(entity);
        }
    }
}
