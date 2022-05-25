using Mc2.CrudTest.Common;
using Mc2.CrudTest.Customers.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _uow;
        public CustomerService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<GetCustomersOutput> GetCustomers(GetCustomersInput model)
        {
            var result = new GetCustomersOutput();
            
            var customers = _uow.Customers.GetAll();

            result.TotalCount = await customers.CountAsync();
            result.CurrentPage = model.CurrentPage;
            result.PageCount = model.PageCount;

            customers = customers
                .OrderBy(r => r.Firstname)
                .ThenBy(r => r.Lastname)
                .Skip((model.CurrentPage - 1) * model.PageCount)
                .Take(model.PageCount)
                .AsNoTracking();

            var list = await customers.Select(r => new
            {
                r.Id,
                r.Firstname,
                r.Lastname,
                r.Email,
                r.DateOfBirth,
                r.PhoneNumber
            }).ToListAsync();

            result.Customers = list.Select(r => new CustomerDto()
            {
                DateOfBirth = r.DateOfBirth,
                Email = r.Email,
                Lastname = r.Lastname,
                Firstname = r.Firstname,
                PhoneNumber = r.PhoneNumber,
                Id = r.Id
            }).ToArray();

            return result;
        }

    }
}
