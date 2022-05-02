using FluentAssertions;
using Mc2.CrudTest.Data.Implementations;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Commands.Repositories;
using Mc2.CrudTest.Queries.Queries;
using Mc2.CrudTest.TestTools;
using Mc2.CrudTest.TestTools.Database;
using System;
using Xunit;

namespace Mc2.CrudTest.Acceptance.Tests.Add
{
    [Trait("(Acceptance) Add customer", "")]
    public class WithInvalidPhoneNumberFailed
    {
        IInMemoryDatabase<UnitOfWork> database;
        Exception thrownException;
        Guid id;

        /// <summary>
        /// Assume there are no customers.
        /// </summary>
        void Given()
        {
            database = InMemoryDbContext<UnitOfWork>.CreateDatabase(UnitOfWork.Create);
            id = Guid.NewGuid();
        }

        /// <summary>
        /// When we register the customer with an invalid phone number 10
        /// </summary>
        void When()
        {
            var repository = database.InjectContext(context => new CustomerRepository(context));
            var sut = new AddCustomerCommand(repository);

            var dto = TestCustomer.Dto();
            dto.CountryCode = "ZZ";
            dto.PhoneNumber = "foo";

            thrownException = Try.CatchOrNull(() =>
                      sut.Execute(id, dto));
        }

        /// <summary>
        /// Customer information should not be registered
        /// </summary>
        void Then()
        {
            var query = database.InjectContext(context => new GetCustomerListQuery(context));
            var customers = query.Execute();

            Assert.Empty(customers);
        }

        /// <summary>
        /// An invalid phone number error must occur
        /// </summary>
        void And()
        {
            thrownException.Should().NotBeNull();
        }

        [Fact(DisplayName = "An invalid phone number error must occur When we register the customer with an invalid phone number.")]
        void Run()
        {
            Given();
            When();
            Then();
            And();
        }
    }
}
