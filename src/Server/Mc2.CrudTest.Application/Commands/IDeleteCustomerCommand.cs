using Mc2.CrudTest.Application.Infrastructure;
using System;

namespace Mc2.CrudTest.Application.Commands
{
    public interface IDeleteCustomerCommand : ICommand<Guid>
    {
    }
}
