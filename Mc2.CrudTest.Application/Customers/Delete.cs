using Mc2.CrudTest.Application.Core;
using Mc2.CrudTest.Domain.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Application.Customers
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ICustomerRepository repo;

            public Handler(ICustomerRepository repo)
            {
                this.repo = repo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var customer = await repo.FirstOrDefaultAsync(i => i.Id == request.Id);

                if (customer == null) return null;

                var res =await repo.Remove(customer);

                return Result<Unit>.CreateResult(
                    res,
                    Unit.Value,
                    "Failed to delete");
            }
        }
    }
}