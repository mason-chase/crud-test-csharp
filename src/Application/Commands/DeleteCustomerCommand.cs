using MediatR;

namespace CleanArchitecture.Application.Commands;

public class DeleteCustomerCommand : IRequest<bool>
{
    public int Id { get; }

    public DeleteCustomerCommand(int id)
    {
        Id = id;
    }
}
