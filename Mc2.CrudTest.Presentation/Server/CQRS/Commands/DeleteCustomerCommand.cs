using Mc2.CrudTest.Presentation.Server.Models;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.CQRS.Commands
{
    public class DeleteCustomerCommand: IRequest<bool>
    {
        public int Id { get;}

        public DeleteCustomerCommand(int id)
        {
            Id = id;
        }
    }
}
