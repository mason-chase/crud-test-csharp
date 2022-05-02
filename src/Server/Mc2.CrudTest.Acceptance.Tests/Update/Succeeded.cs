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

namespace Mc2.CrudTest.Acceptance.Tests.Update
{
    [Trait("(Acceptance) Update customer", "")]
    public class Succeeded
    {
        IInMemoryDatabase<UnitOfWork> database;
        Customer customer;
        CustomerDto dto;

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
        /// When we edit customer information
        /// </summary>
        void When()
        {
            var repository = database.InjectContext(context => new CustomerRepository(context));
            var sut = new UpdateCustomerCommand(repository);

            dto = TestCustomer.Dto();

            sut.Execute(customer.Id, dto);
        }

        /// <summary>
        /// There must be a customer with new information.
        /// </summary>
        void Then()
        {
            var query = database.InjectContext(context => new GetCustomerQuery(context));
            var result = query.Execute(customer.Id);

            result.Id.Should().Be(customer.Id);
            result.FirstName.Should().Be(dto.FirstName);
            result.LastName.Should().Be(dto.LastName);
            result.DateOfBirth.Should().Be(dto.DateOfBirth);
            result.CountryCode.Should().Be(dto.CountryCode);
            result.PhoneNumber.Should().Be(dto.PhoneNumber);
            result.Email.Should().Be(dto.Email);
            result.BankAccountNumber.Should().Be(dto.BankAccountNumber);
        }

        [Fact(DisplayName = "There must be registered customer information when we register customer information.")]
        void Run()
        {
            Given();
            When();
            Then();
        }
    }
}
