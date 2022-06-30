using Mc2.CrudTest.Domain.Entities;
using MediatR;

namespace Mc2.CrudTest.Domain.Queries
{
    public class GetCustomerById : IRequest<Customer>
    {
        public long CustomerId { get; set; }
    }
}
