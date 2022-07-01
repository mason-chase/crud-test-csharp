using Mc2.CrudTest.Domain.Entities;
using MediatR;

namespace Mc2.CrudTest.Domain.Queries
{
    public class GetAllCustomersQuery : IRequest<List<Customer>>
    {
    }
}
