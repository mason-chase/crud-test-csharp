using FluentAssertions;
using Mc2.CrudTest.Application.Repositories;
using Mc2.CrudTest.Data.Implementations;
using Mc2.CrudTest.Domain.Commands.Repositories;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.TestTools;
using Mc2.CrudTest.TestTools.Database;
using System;
using System.Linq;
using Xunit;

namespace Mc2.CrudTest.Domain.Commands.Tests.Repositories
{
    [Trait("(Repository) Customer", "")]
    public class CustomerRepositoryTests
    {
        IInMemoryDatabase<UnitOfWork> database;
        ICustomerRepository sut;

        public CustomerRepositoryTests()
        {
            database = InMemoryDbContext<UnitOfWork>.CreateDatabase(UnitOfWork.Create);
            sut = database.InjectContext(context => new CustomerRepository(context));
        }

        [Fact]
        void Add_CustomerAdded()
        {
            var customer = TestCustomer.Create();
            sut.Add(customer);

            var expectedCustomer = database.InjectContext(context => context
                .Customers.SingleOrDefault(c => c.Id == customer.Id));

            expectedCustomer.Should().NotBeNull();
        }


        [Fact]
        void GetByNameAndDateOfBirth_CustomerReturned()
        {
            var customer = TestCustomer.Create();

            database.Manipulate(context => context.Customers.Add(customer));

            var result = sut.GetBy(Guid.NewGuid(), customer.Name, customer.DateOfBirth);

            result.Should().Match<Customer>(c 
                => c.Name.Equals(customer.Name)
                && c.DateOfBirth == customer.DateOfBirth);
        }


        [Fact]
        void GetByEmail_CustomerReturned()
        {
            var customer = TestCustomer.Create();

            database.Manipulate(context => context.Customers.Add(customer));

            var result = sut.GetBy(Guid.NewGuid(), customer.Email.Value);

            result.Should().Match<Customer>(c => c.Email.Value == customer.Email.Value);
        }

        [Fact]
        void GetById_CustomerReturned()
        {
            var customer = TestCustomer.Create();

            database.Manipulate(context => context.Customers.Add(customer));

            var result = sut.GetById(customer.Id);

            result.Should().NotBeNull();
            result.Id.Should().Be(customer.Id);
        }

        [Fact]
        void Delete_CustomerDeleted()
        {
            var customer = TestCustomer.Create();

            database.Manipulate(context => context.Customers.Add(customer));

            sut.Delete(customer);

            var result = database.InjectContext(context => context.Customers.Find(customer.Id));

            result.Should().BeNull();
        }
    }
}
