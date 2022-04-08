using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Model;
using DotNetCore.Objects;
using DotNetCore.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Database;

public interface ICustomerRepository : IRepository<Customer>
{

    Task<CustomerModel> GetModelAsync(long id);

    Task<Grid<CustomerModel>> GridAsync(GridParameters parameters);

    Task<IEnumerable<CustomerModel>> ListModelAsync();

}
