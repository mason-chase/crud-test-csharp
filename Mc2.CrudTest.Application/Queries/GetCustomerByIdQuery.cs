using Mc2.CrudTest.Domain.Models.Entities;
using MediatR;

namespace c2.CrudTest.Application.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerEntity>
    {
        public int Id { get; set; }
        
    }
}
