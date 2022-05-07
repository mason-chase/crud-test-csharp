using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Presentation.Server.CQRS.Commands;
using Mc2.CrudTest.Presentation.Server.Models;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Queries
{
    public class DeleteCustomerHandler: IRequestHandler<DeleteCustomerCommand, bool>
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
}
