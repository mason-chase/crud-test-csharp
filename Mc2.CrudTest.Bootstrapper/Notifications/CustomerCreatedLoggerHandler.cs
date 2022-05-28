using MediatR;
using Microsoft.Extensions.Logging;

namespace Mc2.CrudTest.Bootstrapper.Notifications;

public class CustomerCreatedLoggerHandler : INotificationHandler<CustomerCreatedEvent>
{
    public CustomerCreatedLoggerHandler(ILogger<CustomerCreatedLoggerHandler> logger!!) => Logger = logger;

    public ILogger<CustomerCreatedLoggerHandler> Logger { get; }

    public Task Handle(CustomerCreatedEvent notification, CancellationToken cancellationToken)
    {
        var title =
            $"New customer has been created at" +
            $" {notification.RegistrationDate}: {notification.FirstName} {notification.LastName}"
        ;

        Logger.LogInformation(title);

        return Task.CompletedTask;
    }
}