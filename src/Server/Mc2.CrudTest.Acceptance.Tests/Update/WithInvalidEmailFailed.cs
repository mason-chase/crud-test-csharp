using FluentAssertions;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Data.Implementations;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Commands.Repositories;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.Domain.Model.Exceptions;
using Mc2.CrudTest.Queries.Queries;
using Mc2.CrudTest.TestTools;
using Mc2.CrudTest.TestTools.Database;
using System;
using Xunit;

namespace Mc2.CrudTest.Acceptance.Tests.Update
{
    [Trait("(Acceptance) Update customer", "")]
    public class WithInvalidEmailFailed
    {
        IInMemoryDatabase<UnitOfWork> database;
        Customer customer;
        Exception thrownException;

        /// <summary>
        /// Assume there is a customer with valid email parisa.hadadinia91@gmail.com
        /// </summary>
        void Given()
        {
            database = InMemoryDbContext<UnitOfWork>.CreateDatabase(UnitOfWork.Create);

            customer = TestCustomer.Create();

            database.Manipulate(context => context.Customers.Add(customer));
        }

        /// <summary>
        /// When we edit the customer with valid an email parisa.hadadinia91@gmail.com to invalid email ss
        /// </summary>
        void When()
        {
            var repository = database.InjectContext(context => new CustomerRepository(context));
            var sut = new UpdateCustomerCommand(repository);

            var dto = TestCustomer.Dto();
            dto.Email = "sss";

            thrownException = Try.CatchOrNull(() =>
                    sut.Execute(customer.Id, dto));
        }

        /// <summary>
        /// Customer information should not be edited
        /// </summary>
        void Then()
        {
            var query = database.InjectContext(context => new GetCustomerQuery(context));
            var findCustomer = query.Execute(customer.Id);


            findCustomer.Email.Should().Be(customer.Email.Value);
        }

        /// <summary>
        /// An invalid email error must occur
        /// </summary>
        void And()
        {
            thrownException.Should().NotBeNull();
            thrownException.Should()
                   .BeOfType<InvalidCustomerEmailException>();
        }

        [Fact(DisplayName = "An invalid email error must occur When we edit the customer with an invalid email.")]
        void Run()
        {
            Given();
            When();
            Then();
            And();
        }
    }
}
