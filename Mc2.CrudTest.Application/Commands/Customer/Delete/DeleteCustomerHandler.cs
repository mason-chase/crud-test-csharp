using Mc2.CrudTest.Application.Common.Interfaces.Repository;
using Mc2.CrudTest.Domain.DomainService.Customer;
using MediatR;

namespace Mc2.CrudTest.Application.Commands.Customer.Delete
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IBaseRepository<Mc2.CrudTest.Domain.Entities.Customer> _baseRepository;
        private CustomerDomainService _customerDomainService;
        public DeleteCustomerHandler(IBaseRepository<Domain.Entities.Customer> baseRepository)
        {
            _baseRepository = baseRepository;
            _customerDomainService = new CustomerDomainService();
        }



        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var id = new Guid(request.Id);
            var result = _baseRepository.FindById(id);
            if (result is not null)
            {
               
                _baseRepository.Delete(id);
                return await Unit.Task;
            }
            throw new Exception("The id doesn't exist");
        }
    }
}
