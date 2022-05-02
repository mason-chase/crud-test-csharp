using Mc2.CrudTest.Application.Repositories;
using Mc2.CrudTest.Data.Contracts;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.Domain.Model.ValueObject;
using System;
using System.Linq;

namespace Mc2.CrudTest.Domain.Commands.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly IUnitOfWork _uow;
        public CustomerRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }


        public void Add(Customer entity)
        {
            _uow.Customers.Add(entity);
            _uow.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            _uow.Customers.Remove(entity);
            _uow.SaveChanges();
        }

        public Customer GetById(Guid customerId)
        {
            return _uow.Customers
             .FirstOrDefault(_ => _.Id == customerId);
        }

        public Customer GetBy(Guid id, Name name, DateTime dateOfBirth)
        {
            return _uow.Customers
                .FirstOrDefault(_ => _.Id != id
                             && _.Name.First == name.First
                             && _.Name.Last == name.Last
                             && _.DateOfBirth == dateOfBirth);
        }

        public Customer GetBy(Guid id, string email)
        {
            return _uow.Customers
               .FirstOrDefault(_ => _.Id != id && _.Email.Value == email);
        }

        public void Update(Customer entity)
        {
            _uow.SaveChanges();
        }
    }
}
