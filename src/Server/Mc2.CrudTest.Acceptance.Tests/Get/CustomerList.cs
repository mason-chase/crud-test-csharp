using FluentAssertions;
using Mc2.CrudTest.Data.Implementations;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.Queries.Queries;
using Mc2.CrudTest.Queries.ViewModel;
using Mc2.CrudTest.TestTools;
using Mc2.CrudTest.TestTools.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Mc2.CrudTest.Acceptance.Tests.Get
{
    [Trait("(Acceptance) Get customer", "")]
    public class CustomerList
    {
        IInMemoryDatabase<UnitOfWork> database;
        IList<CustomerViewModel> result;
        Customer customer1;
        Customer customer2;

        /// <summary>
        /// Assume there are two customers with named Parisa Haddadinia and date of birth on 1/2/1992 and phone Number 09175660499 and email parisa.hadadinia91@gmail.com.
        /// And named sara ahmadi and date of birth on 1/2/1993 and phone Number 09171235269 and email sara.ahmadi@gmail.com
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
        /// When we request a list of customers
        /// </summary>
        void When()
        {
            GetCustomerListQuery sut = database.InjectContext(context => new GetCustomerListQuery(context));

            result = sut.Execute();
        }

        /// <summary>
        /// Two customers must be returned
        /// </summary>
        void Then()
        {
            var findCustomer1 = database.InjectContext(context => context.Customers.Find(customer1.Id));

            var findCustomer2 = database.InjectContext(context => context.Customers.Find(customer2.Id));

            result.Should().Contain(c => c.FirstName == findCustomer1.Name.First && c.LastName == findCustomer1.Name.Last
               && c.DateOfBirth == findCustomer1.DateOfBirth);

            result.Should().Contain(c => c.FirstName == findCustomer2.Name.First && c.LastName == findCustomer2.Name.Last
              && c.DateOfBirth == findCustomer2.DateOfBirth);
        }


        [Fact(DisplayName = "The existing customer list must be returned when we request the customer list.")]
        void Run()
        {
            Given();
            When();
            Then();
        }
    }
}
