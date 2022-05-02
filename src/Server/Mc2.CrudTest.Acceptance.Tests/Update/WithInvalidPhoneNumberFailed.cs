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
    public class WithInvalidPhoneNumberFailed
    {
        IInMemoryDatabase<UnitOfWork> database;
        Customer customer;
        Exception thrownException;

        /// <summary>
        /// Assume there is a customer with valid phone number 09175660499
        /// </summary>
        void Given()
        {
            database = InMemoryDbContext<UnitOfWork>.CreateDatabase(UnitOfWork.Create);

            customer = TestCustomer.Create();

            database.Manipulate(context => context.Customers.Add(customer));
        }

        /// <summary>
        /// When we edit the customer with valid phone number 09175660499 to invalid phon number 10
        /// </summary>
        void When()
        {
            var repository = database.InjectContext(context => new CustomerRepository(context));
            var sut = new UpdateCustomerCommand(repository);

            var dto = TestCustomer.Dto();
            dto.CountryCode = "ZZ";
            dto.PhoneNumber = "foo";

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


            findCustomer.CountryCode.Should().Be(customer.PhoneNumber.CountryCode);
            findCustomer.PhoneNumber.Should().Be(customer.PhoneNumber.Number);
        }

        /// <summary>
        /// An invalid phone number error must occur
        /// </summary>
        void And()
        {
            thrownException.Should().NotBeNull();
        }

        [Fact(DisplayName = "An invalid phone number error must occur When we edit the customer with an invalid phone number.")]
        void Run()
        {
            Given();
            When();
            Then();
            And();
        }
    }
}
