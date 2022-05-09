using System.Collections;
using System.Collections.Generic;
using Mc2.CrudTest.Presentation.Server.Models;
using MediatR;

namespace Mc2.CrudTest.Presentation.Server.Queries
{
    public class GetAllCustomerQuery: IRequest<List<Customer>>
    {
        
    }
}
