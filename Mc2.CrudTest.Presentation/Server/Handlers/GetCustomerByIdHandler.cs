using Mc2.CrudTest.DataLayer.Entities;
using Mc2.CrudTest.DataLayer.Repository;
using Mc2.CrudTest.Presentation.Server.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var Customer = await _customerRepository.GetEntity(request.FirstName,request.LastName,request.DateOfBirth);
            return Customer;
        }
    }
}
