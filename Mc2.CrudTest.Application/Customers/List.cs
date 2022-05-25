using Mc2.CrudTest.Application.Core;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Interfaces;
using MediatR;

namespace Mc2.CrudTest.Application.Customers
{
    public class List
    {
        public class Query : IRequest<Result<IEnumerable<Customer>>> { }

        public class Handler : IRequestHandler<Query, Result<IEnumerable<Customer>>>
        {
            private readonly ICustomerRepository repo;

            public Handler(ICustomerRepository repo)
            {
                this.repo = repo;
            }

            public async Task<Result<IEnumerable<Customer>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = await repo.GetAllAsync();

                return Result<IEnumerable<Customer>>.Success(query);
            }
        }
    }
}
