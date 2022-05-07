using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Presentation.Server.Models;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Queries
{
    public class GetAllCustomerQueryHandler: IRequestHandler<GetAllCustomerQuery, List<Customer>>
    {
        private readonly ICustomerRepository _repository;
        public GetAllCustomerQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            List<Customer> customers = await _repository.GetList();
            return customers;
        }
    }
}
