using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Model;

namespace Mc2.CrudTest.Application;

public interface ICustomerFactory
{
    Customer Create(CustomerModel model);
}
