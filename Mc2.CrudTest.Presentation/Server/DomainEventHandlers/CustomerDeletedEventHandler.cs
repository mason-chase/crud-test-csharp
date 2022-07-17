namespace Mc2.CrudTest.Presentation.Server.DomainEventHandlers.UserDeleted
{
    using global::Domain.AggregatesModel.CustomerAggregate;
    using global::Domain.Events;
    using Mc2.CrudTest.Presentation.Server.Domain;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;


    public class CustomerDeletedDomainHandler
                   : INotificationHandler<CustomerDeletedEvent>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerIntegrationEventService _customerIntegrationEventService;


        public CustomerDeletedDomainHandler(
                ICustomerRepository customerRepository,
                ICustomerIntegrationEventService customerIntegrationEventService)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _customerIntegrationEventService = customerIntegrationEventService;
        }

        public async Task Handle(CustomerDeletedEvent customerDeletedEvent, CancellationToken cancellationToken)
        {
            _customerRepository.Delete(customerDeletedEvent.Identity);

            await _customerIntegrationEventService.AddAndSaveEventAsync(customerDeletedEvent);
        }
    }
}


