using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Application.Common.Interfaces;
using Mc2.CrudTest.Application.Common.Exceptions;

namespace Mc2.CrudTest.Application.Administration.Customers.Commands
{
    #region command

    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }

    #endregion;

    #region handler

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteCustomerCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Customers.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            _dbContext.Customers.Remove(entity);

            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }

    #endregion;
}
