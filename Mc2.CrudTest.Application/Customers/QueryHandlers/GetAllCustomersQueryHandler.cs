using Mc2.CrudTest.DataAccess;
using Mc2.CrudTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Queries;

namespace Mc2.CrudTest.Application.Customers.QueryHandlers
{
    public class GetAllCustomersQueryHandler
    {
        private readonly DataContext _dataContext;
        public GetAllCustomersQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Customer>> Handle(GetAllCustomers request)
        {
            return await _dataContext.Customers.ToListAsync();
        }

    }
}
