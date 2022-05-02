using FluentAssertions;
using Mc2.CrudTest.Data.Implementations;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.Queries.Queries;
using Mc2.CrudTest.Queries.ViewModel;
using Mc2.CrudTest.TestTools;
using Mc2.CrudTest.TestTools.Database;
using System;
using Xunit;

namespace Mc2.CrudTest.Acceptance.Tests.Get
{
    [Trait("(Acceptance) Get customer", "")]
    public class OneCustomer
    {
        IInMemoryDatabase<UnitOfWork> database;
        Customer customer;
        CustomerViewModel result;

        /// <summary>
        /// Assume there is a customer with named Parisa Haddadinia and date of birth on 1/2/1992 and phone Number 09175660499 and email parisa.hadadinia91@gmail.com.
        /// </summary>
        void Given()
        {
            database = InMemoryDbContext<UnitOfWork>.CreateDatabase(UnitOfWork.Create);

            customer = TestCustomer.Create();

            database.Manipulate(context => context.Customers.Add(customer));
        }

        /// <summary>
        /// When we request a customer with named Parisa Haddadinia and date of birth on 1/2/1992 and phone Number 09175660499 and email parisa.hadadinia91@gmail.com.
        /// </summary>
        void When()
        {
            GetCustomerQuery sut = database.InjectContext(context => new GetCustomerQuery(context));

            result = sut.Execute(customer.Id);
        }

        /// <summary>
        /// a customer with named Parisa Haddadinia and date of birth on 1/2/1992 and phone Number 09175660499 and email parisa.hadadinia91@gmail.com must be returned
        /// </summary>
        void Then()
        {
            var findCustomer = database.InjectContext(context => context.Customers.Find(customer.Id));

            findCustomer.Name.First.Should().Be(result.FirstName);
            findCustomer.Name.Last.Should().Be(result.LastName);
            findCustomer.DateOfBirth.Should().Be(result.DateOfBirth);
        }


        [Fact(DisplayName = "When we request a customer with an ID, the same customer must be returned.")]
        void Run()
        {
            Given();
            When();
            Then();
        }
    }
}
