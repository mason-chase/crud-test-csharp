using Mc2.CrudTest.Dtos;

namespace Mc2.CrudTest.Customers.Dtos
{
    public class GetCustomersOutput  : PaginateOutput
    {
        public CustomerDto[] Customers { get; set; }
    }
}
