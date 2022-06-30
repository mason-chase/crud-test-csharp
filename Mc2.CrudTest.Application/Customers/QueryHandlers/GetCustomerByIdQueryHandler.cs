using Mc2.CrudTest.DataAccess;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Queries;
using MediatR;

namespace Mc2.CrudTest.Application.Customers.QueryHandlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerById, Customer>
    {
        private DataContext _dataContext;
        public GetCustomerByIdQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Customer> Handle(GetCustomerById request, CancellationToken cancellationToken)
        {
            return await _dataContext.Customers.FirstOrDefaultAsync(c => c.Id == request.CustomerId);
        }
    }
}
