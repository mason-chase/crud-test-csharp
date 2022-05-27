using Mc2.CrudTest.Common;
using Mc2.CrudTest.Customers.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<GetCustomersOutput> GetCustomers(GetCustomersInput input)
        {
            var result = new GetCustomersOutput();

            var customers = _uow.Customers.GetAll();

            result.TotalCount = await customers.CountAsync();
            result.CurrentPage = input.CurrentPage;
            result.PageCount = input.PageCount;

            customers = customers
                .OrderBy(r => r.Firstname)
                .ThenBy(r => r.Lastname)
                .Skip((input.CurrentPage - 1) * input.PageCount)
                .Take(input.PageCount)
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

        public async Task<GetCustomerOutput> GetCustomer(GetCustomerInput input)
        {
            var result = new GetCustomerOutput();

            var customer = await _uow.Customers
                .GetAll()
                .FirstOrDefaultAsync(r => r.Id == input.Id);

            if (customer == null)
                throw new Exception("Customer does not found!!!");

            result.Customer = new CustomerDto()
            {
                DateOfBirth = customer.DateOfBirth,
                Email = customer.Email,
                Lastname = customer.Lastname,
                Firstname = customer.Firstname,
                PhoneNumber = customer.PhoneNumber,
                Id = customer.Id
            };

            return result;
        }

        public async Task<UpsertCustomerOutput> UpsertCustomer(UpsertCustomerInput input)
        {
            Customer customer = null;

            if (input.Id != 0)
            {
                customer = await _uow.Customers.GetByIdAsync(input.Id);
                if (customer == null)
                {
                    throw new Exception("Customer coes not found!!!");
                }
            }
            else
            {
                customer = new Customer();
                await _uow.Customers.AddAsync(customer);
            }

            customer.Firstname = input.Firstname;
            customer.Lastname = input.Lastname;
            customer.DateOfBirth = input.DateOfBirth;
            customer.Email = input.Email;
            customer.PhoneNumber = input.PhoneNumber;

            await _uow.CompleteAsync();

            return new UpsertCustomerOutput();
        }

        public async Task<DeleteCustomerOutput> DeleteCustomer(DeleteCustomerInput input)
        {
            var customer = await _uow.Customers.GetByIdAsync(input.Id);
            if (customer != null)
            {
                _uow.Customers.Remove(customer);
                await _uow.CompleteAsync();
            }
            else
            {
                throw new Exception("Custoemr does not found!!!");
            }
            return new DeleteCustomerOutput();
        }
    }
}
