using MediatR;

namespace Mc2.CrudTest.Application.Commands.Customer.Delete
{
    public class DeleteCustomerCommand : IRequest
    {
        public string Id { get; set; }
    }
}
