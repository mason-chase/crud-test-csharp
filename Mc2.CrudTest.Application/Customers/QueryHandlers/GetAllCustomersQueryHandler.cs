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
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<Customer>>
    {
        private readonly DataContext _dataContext;
        public GetAllCustomersQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _dataContext.Customers.ToListAsync();
        }

    }
}
