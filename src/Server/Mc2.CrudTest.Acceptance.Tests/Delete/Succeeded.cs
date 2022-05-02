using Mc2.CrudTest.Data.Implementations;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Commands.Repositories;
using Mc2.CrudTest.Domain.Model;
using Mc2.CrudTest.Queries.Queries;
using Mc2.CrudTest.TestTools;
using Mc2.CrudTest.TestTools.Database;
using Xunit;

namespace Mc2.CrudTest.Acceptance.Tests.Delete
{
    [Trait("(Acceptance) Delete customer", "")]
    public class Succeeded
    {
        IInMemoryDatabase<UnitOfWork> database;
        Customer customer;

        /// <summary>
        /// Assume there is a customer named Parisa Haddadinia and date of birth on 1/2/1992
        /// </summary>
        void Given()
        {
            database = InMemoryDbContext<UnitOfWork>.CreateDatabase(UnitOfWork.Create);

            customer = TestCustomer.Create();

            database.Manipulate(context => context.Customers.Add(customer));
        }

        /// <summary>
        /// When we delete a customer named Parisa Haddadinia and date of birth on 1/2/1992
        /// </summary>
        void When()
        {
            var repository = database.InjectContext(context => new CustomerRepository(context));
            var sut = new DeleteCustomerCommand(repository);

            sut.Execute(customer.Id);
        }

        /// <summary>
        /// Then, there should not be a customer named Parisa Haddadinia and date of birth on 1/2/1992
        /// </summary>
        void Then()
        {
            var query = database.InjectContext(context => new GetCustomerListQuery(context));
            var customers = query.Execute();

            Assert.Empty(customers);
        }

        [Fact(DisplayName = "When we delete the customer so it should not be in the customer list.")]
        void Run()
        {
            Given();
            When();
            Then();
        }
    }
}
