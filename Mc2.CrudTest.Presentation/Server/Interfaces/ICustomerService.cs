using Mc2.CrudTest.Application.Commands.Customer.Create;
using Mc2.CrudTest.Application.Commands.Customer.Delete;
using Mc2.CrudTest.Application.Commands.Customer.Edit;
using Mc2.CrudTest.Application.Queries.Customer.GetAll;
using Mc2.CrudTest.Application.Queries.Customer.GetById;
using Mc2.CrudTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Mc2.CrudTest.Presentation.Server.Interfaces
{
    public interface ICustomerService
    {
        Task<Guid> CreateAsync(CreateCustomerCommand dto);
        Task<EditCustomerCommand> UpdateAsync(EditCustomerCommand dto);
        Task DeleteAsync(DeleteCustomerCommand dto);
        Task<List<Customer>> GetAllAsync(GetAllCustomerQuery dto);
        Task<Customer> GetByIdAsync(GetCustomerByIdQuery dto);
    }
}
