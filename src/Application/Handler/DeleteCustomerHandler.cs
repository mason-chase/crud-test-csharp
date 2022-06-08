using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Commands;
using CleanArchitecture.Application.Repositories;
using MediatR;

namespace CleanArchitecture.Application.Handler;

public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly ICustomerRepository _repository;
    public DeleteCustomerHandler(ICustomerRepository repository)
    {
        _repository = repository;
    }
    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var res = await _repository.Delete(request.Id);
        if (res is not true)
            return false;
        await _repository.SaveChanges();
        return res;
    }
}
