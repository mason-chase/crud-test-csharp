using MediatR;

namespace Mc2.CrudTest.Application.Queries.Customer.GetById
{
    public class GetCustomerByIdQuery:IRequest<Mc2.CrudTest.Domain.Entities.Customer>
    {
        public string Id { get; set; }
    }
}
