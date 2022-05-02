using FluentAssertions;
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
    public class WithDuplicateCustomerNameAndDateOfBirthFailed
    {
        IInMemoryDatabase<UnitOfWork> database;
        Customer customer1;
        Customer customer2;
        Exception thrownException;

        /// <summary>
        /// Assume there is a customer with named Parisa Haddadinia and date of birth on 1/2/1992.
        /// And there is a customer with named sara ahmadi and date of birth on 1/2/1993.
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
        /// When we edit the customer with named Parisa Haddadinia and date of birth on 1/2/1992 to the customer with named sara ahmadi and date of birth on 1/2/1993
        /// </summary>
        void When()
        {
            var repository = database.InjectContext(context => new CustomerRepository(context));
            var sut = new UpdateCustomerCommand(repository);

            var dto = TestCustomer.Dto();
            dto.FirstName = customer2.Name.First;
            dto.LastName = customer2.Name.Last;
            dto.DateOfBirth = customer2.DateOfBirth;

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


            customer.FirstName.Should().Be(customer1.Name.First);
            customer.LastName.Should().Be(customer1.Name.Last);
            customer.DateOfBirth.Should().Be(customer1.DateOfBirth);
        }

        /// <summary>
        /// And duplicate information error will occur
        /// </summary>
        void And()
        {
            thrownException.Should().NotBeNull();
            thrownException.Should()
                   .BeOfType<DuplicateCustomerNameAndDateOfBirthException>();
        }

        [Fact(DisplayName = "An error of duplicate information should occur when we edit a customer's information with duplicate information.")]
        void Run()
        {
            Given();
            When();
            Then();
            And();
        }

    }
}
