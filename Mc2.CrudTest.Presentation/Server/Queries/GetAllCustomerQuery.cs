using Mc2.CrudTest.DataLayer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Queries
{
    public class GetAllCustomerQuery : IRequest<List<Customer>>
    {
    }
}
