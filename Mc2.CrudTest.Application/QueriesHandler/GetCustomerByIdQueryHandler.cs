using c2.CrudTest.Application.Queries;
using Mc2.CrudTest.Domain.Models.Entities;
using Mc2.CrudTest.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace c2.CrudTest.Application.QueriesHandler
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerEntity>
    {
        private readonly CustomerDbContext _context;
        public GetCustomerByIdQueryHandler(CustomerDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerEntity> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {

            var customer = _context.Customers.Where(a => a.Id == query.Id).FirstOrDefault();
            if (customer == null) return null;
            return customer;
        }
    }
}
