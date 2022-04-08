using Mc2.CrudTest.Model;
using DotNetCore.Objects;
using DotNetCore.Results;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mc2.CrudTest.Application;

public interface ICustomerService
{
    Task<IResult<long>> AddAsync(CustomerModel model);

    Task<IResult> DeleteAsync(long id);

    Task<CustomerModel> GetAsync(long id);

    Task<Grid<CustomerModel>> GridAsync(GridParameters parameters);

    Task<IEnumerable<CustomerModel>> ListAsync();

    Task<IResult> UpdateAsync(CustomerModel model);
}
