namespace Mc2.CrudTest.Presentation.Server.DomainEventHandlers.UserCreated
{
    using global::Domain.AggregatesModel.CustomerAggregate;
    using global::Domain.Events;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;


    public class CustomerCreatedDomainHandler
                   : INotificationHandler<CustomerCreatedEvent>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerIntegrationEventService _customerIntegrationEventService;


        public CustomerCreatedDomainHandler(
                ICustomerRepository customerRepository,
                ICustomerIntegrationEventService customerIntegrationEventService)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _customerIntegrationEventService = customerIntegrationEventService;
        }

        public async Task Handle(CustomerCreatedEvent customerCreatedEvent, CancellationToken cancellationToken)
        {
            var customer = _customerRepository.Add(customerCreatedEvent.Customer);

            await _customerIntegrationEventService.AddAndSaveEventAsync(CustomerCreatedEvent);
        }
    }
}


