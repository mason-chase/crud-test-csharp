using Mc2.CrudTest.Application.Core;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Application.Customers
{
    public class Detail
    {
        public class Query : IRequest<Result<Customer>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Customer>>
        {
            private readonly ICustomerRepository repo;

            public Handler(ICustomerRepository repo)
            {
                this.repo = repo;
            }

            public async Task<Result<Customer>> Handle(Query request, CancellationToken cancellationToken)
            {
                var customer = await repo.FirstOrDefaultAsync(i => i.Id == request.Id);

                if (customer is null) return null;

                return Result<Customer>.Success(customer);
            }
        }
    }
}
