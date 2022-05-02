using FluentAssertions;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Data.Implementations;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Commands.Repositories;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.Queries.Queries;
using Mc2.CrudTest.TestTools;
using Mc2.CrudTest.TestTools.Database;
using Xunit;
using System;
using Mc2.CrudTest.Domain.Model.Exceptions;

namespace Mc2.CrudTest.Acceptance.Tests.Update
{
    [Trait("(Acceptance) Update customer", "")]
    public class WithDuplicateEmailFailed
    {
        IInMemoryDatabase<UnitOfWork> database;
        Customer customer1;
        Customer customer2;
        Exception thrownException;

        /// <summary>
        /// Assume there is a customer with email parisa.hadadinia91@gmail.com
        /// And there is a customer with email sara.ahmadi@gmail.com
        /// </summary>
        void Given()
        {
            database = InMemoryDbContext<UnitOfWork>.CreateDatabase(UnitOfWork.Create);

            customer1 = TestCustomer.Create();
            customer2 = TestCustomer.Create();

            database.Manipulate(context =>
            {
                context.Customers.Add(customer1);
                context.Customers.Add(customer2);
            });
        }

        /// <summary>
        /// When we edit the customer with email parisa.hadadinia91@gmail.com to customer with email sara.ahmadi@gmail.com
        /// </summary>
        void When()
        {
            var repository = database.InjectContext(context => new CustomerRepository(context));
            var sut = new UpdateCustomerCommand(repository);

            var dto = TestCustomer.Dto();
            dto.Email = customer2.Email.Value;

            thrownException = Try.CatchOrNull(() =>
                    sut.Execute(customer1.Id, dto));
        }


        /// <summary>
        /// Customer information should not be edited
        /// </summary>
        void Then()
        {
            var query = database.InjectContext(context => new GetCustomerQuery(context));
            var customer = query.Execute(customer1.Id);


            customer.Email.Should().Be(customer1.Email.Value);
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

        [Fact(DisplayName = "A duplicate email error must occur when we edit a client in a duplicate email.")]
        void Run()
        {
            Given();
            When();
            Then();
            And();
        }

    }
}
