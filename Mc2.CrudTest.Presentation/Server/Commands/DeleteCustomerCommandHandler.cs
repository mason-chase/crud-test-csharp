using Domain.AggregatesModel.CustomerAggregate;
using MediatR;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Api.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<bool> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            _customerRepository.Delete(command.Id);

            return await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}