using c2.CrudTest.Application.Queries;
using Mc2.CrudTest.Domain.Models.Entities;
using Mc2.CrudTest.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace c2.CrudTest.Application.QueriesHandler
{

    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerEntity>>
    {
        private readonly CustomerDbContext _customerDbContext;
        public GetAllCustomersQueryHandler(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
        public async Task<IEnumerable<CustomerEntity>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
        {
            var customerList = await _customerDbContext.Customers.ToListAsync();
            if (customerList == null)
            {
                return null;
            }
            return customerList.AsReadOnly();
        }
    }
}
