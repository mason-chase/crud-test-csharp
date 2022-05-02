using FluentAssertions;
using Mc2.CrudTest.Data.Implementations;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.Queries.Contracts;
using Mc2.CrudTest.Queries.Queries;
using Mc2.CrudTest.TestTools;
using Mc2.CrudTest.TestTools.Database;
using Xunit;

namespace Mc2.CrudTest.Quesies.Tests
{
    [Trait("(Query) Get Customer", "")]
    public class GetCustomerListQueryTests
    {
        IInMemoryDatabase<UnitOfWork> database;
        IGetCustomerListQuery sut;

        public GetCustomerListQueryTests()
        {
            database = InMemoryDbContext<UnitOfWork>.CreateDatabase(UnitOfWork.Create);
            sut = database.InjectContext(context => new GetCustomerListQuery(context));
        }

        [Fact]
        void Execute_GetCustomerList()
        {
            var customer1 = TestCustomer.Create();
            var customer2 = TestCustomer.Create();
            database.Manipulate(context =>
            {
                context.Customers.Add(customer1);
                context.Customers.Add(customer2);
            });

            var result = sut.Execute();

            result.Should().Contain(c => c.Id == customer1.Id 
                        && c.FirstName == customer1.Name.First
                        && c.LastName == customer1.Name.Last);

            result.Should().Contain(c => c.Id == customer2.Id
                        && c.FirstName == customer2.Name.First
                        && c.LastName == customer2.Name.Last);
        }
    }
}
