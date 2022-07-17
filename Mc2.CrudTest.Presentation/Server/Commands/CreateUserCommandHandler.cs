using Domain.AggregatesModel.CustomerAggregate;
using MediatR;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Api.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateUserCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var customer = _customerRepository.Add(command.Customer);
            if (customer == null)
            {
                return false;
            }

            return await _customerRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}