using c2.CrudTest.Application.Commands;
using Mc2.CrudTest.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace c2.CrudTest.Application.CommandHandler
{
    public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, int>
    {
        private readonly CustomerDbContext _customerDbContext;
        public DeleteCustomerByIdCommandHandler(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        public async Task<int> Handle(DeleteCustomerByIdCommand command, CancellationToken cancellationToken)
        {
            var customer = await _customerDbContext.Customers.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            if (customer == null) return default;
            _customerDbContext.Customers.Remove(customer);
            await _customerDbContext.SaveChangesAsync();
            return customer.Id;
        }
    }
}
