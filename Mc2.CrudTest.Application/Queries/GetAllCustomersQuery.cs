using Mc2.CrudTest.Domain.Models.Entities;
using MediatR;
using System.Collections.Generic;

namespace c2.CrudTest.Application.Queries
{

    public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerEntity>>
    {
       
    }
}
