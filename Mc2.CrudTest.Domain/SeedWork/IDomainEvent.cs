using System;
//using MediatR;

namespace Mc2.CrudTest.Domain.SeedWork;

public interface IDomainEvent //: INotification
{
    DateTime OccurredOn { get; }
}