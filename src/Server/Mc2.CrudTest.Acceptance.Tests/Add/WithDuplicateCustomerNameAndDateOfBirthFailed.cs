using FluentAssertions;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Data.Implementations;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Commands.Repositories;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.Domain.Model.Exceptions;
using Mc2.CrudTest.Domain.Model.ValueObject;
using Mc2.CrudTest.Queries.Queries;
using Mc2.CrudTest.Queries.ViewModel;
using Mc2.CrudTest.TestTools;
using Mc2.CrudTest.TestTools.Database;
using System;
using Xunit;

namespace Mc2.CrudTest.Acceptance.Tests.Add
{
    [Trait("(Acceptance) Add customer", "")]
    public class WithDuplicateCustomerNameAndDateOfBirthFailed
    {
        IInMemoryDatabase<UnitOfWork> database;
        Customer customer;
        Exception thrownException;
        Guid newId;

        /// <summary>
        /// Assume there is a customer named Parisa Haddadinia and date of birth on 1/2/1992
        /// </summary>
        void Given()
        {
            newId = Guid.NewGuid();
            database = InMemoryDbContext<UnitOfWork>.CreateDatabase(UnitOfWork.Create);

            customer = TestCustomer.Create();

            database.Manipulate(context => context.Customers.Add(customer));
        }

        /// <summary>
        /// When we register the customer with named Parisa Haddadinia and date of birth on 1/2/1992
        /// </summary>
        void When()
        {
            var repository = database.InjectContext(context => new CustomerRepository(context));
            var sut = new AddCustomerCommand(repository);

            var dto = TestCustomer.Dto();
            dto.DateOfBirth = customer.DateOfBirth;
            dto.FirstName = customer.Name.First;
            dto.LastName = customer.Name.Last;

            thrownException = Try.CatchOrNull(() => 
                    sut.Execute(newId, dto));
         
        }

        /// <summary>
        /// There should be a customer error with this information
        /// </summary>
        void Then()
        {
            var query = database.InjectContext(context => new GetCustomerListQuery(context));
            var customers = query.Execute();

            Assert.Single(customers);


            thrownException.Should().NotBeNull();
            thrownException.Should()
                   .BeOfType<DuplicateCustomerNameAndDateOfBirthException>();
        }

        [Fact(DisplayName = "There should be a customer error with this information When the customer exists with this information.")]
        void Run()
        {
            Given();
            When();
            Then();
        }

    }
}
