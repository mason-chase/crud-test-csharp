using Mc2.CrudTest.DataLayer.Entities;
using Mc2.CrudTest.DataLayer.Repository;
using Mc2.CrudTest.Presentation.Server.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Handlers
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerQuery, List<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var Customers = await  _customerRepository.GetQuery().AsQueryable().Where(c => c.IsDelete == false).ToListAsync();
            return Customers;
        }
    }
}
