using Mc2.CrudTest.Presentation.Server.Models;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Queries
{
    public class GetCustomerByIdQuery: IRequest<Customer>
    {
        public int Id { get; }

        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }
    }
}
