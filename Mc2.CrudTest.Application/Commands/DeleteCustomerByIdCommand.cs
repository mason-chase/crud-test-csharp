using MediatR;

namespace c2.CrudTest.Application.Commands
{
    public class DeleteCustomerByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
