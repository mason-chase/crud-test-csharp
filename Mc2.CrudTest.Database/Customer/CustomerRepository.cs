using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Model;
using DotNetCore.EntityFrameworkCore;
using DotNetCore.Objects;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mc2.CrudTest.Database;

public sealed class CustomerRepository : EFRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(Context context) : base(context) { }

    public Task<CustomerModel> GetModelAsync(long id)
    {
        return Queryable.Where(CustomerExpression.Id(id)).Select(CustomerExpression.Model).SingleOrDefaultAsync();
    }

    public Task<Grid<CustomerModel>> GridAsync(GridParameters parameters)
    {
        return Queryable.Select(CustomerExpression.Model).GridAsync(parameters);
    }

    public async Task<IEnumerable<CustomerModel>> ListModelAsync()
    {
        return await Queryable.Select(CustomerExpression.Model).ToListAsync();
    }

}
