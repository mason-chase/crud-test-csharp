using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.Domain.Model.ValueObject;
using System;

namespace Mc2.CrudTest.Application.Repositories
{
    public interface ICustomerRepository
    {
        void Add(Customer entity);
        void Update(Customer entity);
        void Delete(Customer entity);
        Customer GetById(Guid customerId);
        Customer GetBy(Guid id, Name name, DateTime dateOfBirth);
        Customer GetBy(Guid id, string email);
    }
}
