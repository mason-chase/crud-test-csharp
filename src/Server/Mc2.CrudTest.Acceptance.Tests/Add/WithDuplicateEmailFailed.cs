using FluentAssertions;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Data.Implementations;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Commands.Repositories;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.Domain.Model.Exceptions;
using Mc2.CrudTest.Domain.Model.ValueObject;
using Mc2.CrudTest.Queries.Queries;
using Mc2.CrudTest.TestTools;
using Mc2.CrudTest.TestTools.Database;
using System;
using Xunit;

namespace Mc2.CrudTest.Acceptance.Tests.Add
{
    [Trait("(Acceptance) Add customer", "")]
    public class WithDuplicateEmailFailed
    {
        IInMemoryDatabase<UnitOfWork> database;
        Customer customer;
        Exception thrownException;


        /// <summary>
        /// Assume there is a customer with email parisa.hadadinia91@gmail.com
        /// </summary>
        void Given()
        {
            database = InMemoryDbContext<UnitOfWork>.CreateDatabase(UnitOfWork.Create);

            customer = TestCustomer.Create();

            database.Manipulate(context => context.Customers.Add(customer));
        }

        /// <summary>
        /// When we register the customer with the email parisa.hadadinia91@gmail.com
        /// </summary>
        void When()
        {
            var repository = database.InjectContext(context => new CustomerRepository(context));
            var sut = new AddCustomerCommand(repository);

            var dto = TestCustomer.Dto();
            dto.Email = customer.Email.Value;

            thrownException = Try.CatchOrNull(() =>
                    sut.Execute(Guid.NewGuid(), dto));
        }

        /// <summary>
        /// There should be only one the email parisa.hadadinia91@gmail.com
        /// </summary>
        void Then()
        {
            var query = database.InjectContext(context => new GetCustomerListQuery(context));
            var customers = query.Execute();

            Assert.Single(customers);
        }

        /// <summary>
        /// A duplicate email error should occur
        /// </summary>
        void And()
        {
            thrownException.Should().NotBeNull();
            thrownException.Should()
                   .BeOfType<DuplicateCustomerEmailException>();
        }

        [Fact(DisplayName = "A duplicate email error should occur When we register the customer with the duplicate email.")]
        void Run()
        {
            Given();
            When();
            Then();
            And();
        }

    }
}
