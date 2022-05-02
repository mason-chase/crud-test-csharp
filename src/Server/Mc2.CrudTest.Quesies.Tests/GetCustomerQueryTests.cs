using FluentAssertions;
using Mc2.CrudTest.Data.Implementations;
using Mc2.CrudTest.Queries.Contracts;
using Mc2.CrudTest.Queries.Queries;
using Mc2.CrudTest.TestTools;
using Mc2.CrudTest.TestTools.Database;
using Xunit;

namespace Mc2.CrudTest.Quesies.Tests
{
    [Trait("(Query) Get Customer", "")]
    public class GetCustomerQueryTests
    {
        IInMemoryDatabase<UnitOfWork> database;
        IGetCustomerQuery sut;

        public GetCustomerQueryTests()
        {
            database = InMemoryDbContext<UnitOfWork>.CreateDatabase(UnitOfWork.Create);
            sut = database.InjectContext(context => new GetCustomerQuery(context));
        }

        [Fact]
        void Execute_GetCustomer()
        {
            var customer = TestCustomer.Create();
            database.Manipulate(context =>
            {
                context.Customers.Add(customer);
            });

            var result = sut.Execute(customer.Id);

            result.FirstName.Should().Be(customer.Name.First);
            result.LastName.Should().Be(customer.Name.Last);
            result.DateOfBirth.Should().Be(customer.DateOfBirth);
        }
    }
}
