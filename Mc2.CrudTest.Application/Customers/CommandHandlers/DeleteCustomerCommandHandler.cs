using Mc2.CrudTest.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Commands;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.CommandHandlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly DataContext _dataContext;
        public DeleteCustomerCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {

            var customer = await _dataContext.Customers.FirstOrDefaultAsync(c => c.Id == request.Id);
            if (customer is null) return new Unit();
            _dataContext.Customers.Remove(customer);
            await _dataContext.SaveChangesAsync();
            return new Unit();
        }

    }
}
