using Mc2.CrudTest.Application.Infrastructure;

namespace Mc2.CrudTest.Application.Commands
{
    public interface IAddCustomerCommand : ICommand<CustomerDto>
    {
    }
}
