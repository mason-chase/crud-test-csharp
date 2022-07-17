using Domain.AggregatesModel.CustomerAggregate;
using MediatR;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Api.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteUserCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<bool> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            _customerRepository.Delete(command.Id);

            return await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}