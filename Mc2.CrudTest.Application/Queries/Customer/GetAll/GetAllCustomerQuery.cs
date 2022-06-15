using MediatR;

namespace Mc2.CrudTest.Application.Queries.Customer.GetAll
{
    public class GetAllCustomerQuery:IRequest<List<Mc2.CrudTest.Domain.Entities.Customer>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
