using Mc2.CrudTest.Domain.Entities;
using MediatR;

namespace Mc2.CrudTest.Domain.Commands
{
    public class DeleteCustomerCommand : IRequest
    {
        public long Id { get; set; }
    }
}
