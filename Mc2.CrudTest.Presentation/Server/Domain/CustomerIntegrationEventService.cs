using Domain.Events;
using Domain.Events.EventLog;
using Infrastructure;
using Mc2.CrudTest.Presentation.Server.Domain.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Domain
{
    public class CustomerIntegrationEventService : ICustomerIntegrationEventService
    {
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly CustomerContext _customerContext;
        private readonly IIntegrationEventLogService _eventLogService;

        public CustomerIntegrationEventService(
            CustomerContext customerContext,
            IntegrationEventLogContext eventLogContext,
            Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory
          )
        {
            _customerContext = customerContext ?? throw new ArgumentNullException(nameof(customerContext));
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
             _eventLogService = _integrationEventLogServiceFactory(_customerContext.Database.GetDbConnection());
        }


        public async Task AddAndSaveEventAsync(IntegrationEvent evt)
        {
            await _eventLogService.SaveEventAsync(evt, _customerContext.GetCurrentTransaction());
        }
    }
}
