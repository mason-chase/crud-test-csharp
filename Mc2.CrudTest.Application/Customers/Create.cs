using FluentValidation;
using Mc2.CrudTest.Application.Core;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Interfaces;
using MediatR;
using System.Data.SqlClient;

namespace Mc2.CrudTest.Application.Customers
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Customer Customer { get; set; }
        }

        public class CommandValidaor : AbstractValidator<Command>
        {
            public CommandValidaor()
            {
                RuleFor(x => x.Customer).SetValidator(new CustomerValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ICustomerRepository repo;

            public Handler(
                ICustomerRepository repo)
            {
                this.repo = repo;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                try
                {
                    var res = await repo.AddAsync(request.Customer);

                    return Result<Unit>.CreateResult(
                        res,
                        Unit.Value,
                        "Failed to create customer");
                }
                catch (SqlException exception)
                {
                    if (exception.Number == 2601) return Result<Unit>.Failure("Email is used by another user");
                    else throw;
                }
            }
        }
    }
}
