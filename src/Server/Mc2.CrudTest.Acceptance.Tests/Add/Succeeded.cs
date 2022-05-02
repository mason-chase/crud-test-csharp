using FluentAssertions;
using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Data.Implementations;
using Mc2.CrudTest.Domain.Commands;
using Mc2.CrudTest.Domain.Commands.Repositories;
using Mc2.CrudTest.Queries.Queries;
using Mc2.CrudTest.Queries.ViewModel;
using Mc2.CrudTest.TestTools;
using Mc2.CrudTest.TestTools.Database;
using System;
using Xunit;

namespace Mc2.CrudTest.Acceptance.Tests.Add
{
    [Trait("(Acceptance) Add customer", "")]
    public class Succeeded
    {
        IInMemoryDatabase<UnitOfWork> database;
        CustomerDto dto = new CustomerDto();
        Guid id;

        public Succeeded()
        {
            database = InMemoryDbContext<UnitOfWork>.CreateDatabase(UnitOfWork.Create);
            id = Guid.NewGuid();
        }


        /// <summary>
        /// Assume there are no customers.
        /// </summary>
        void Given()
        {
        }

        /// <summary>
        /// When we register a customer's information with named Parisa Haddadinia and date of birth on 1/2/1992 and email parisa.hadadinia91@gmail.com and bank account number 11 and phone nunber 09175660499.
        /// </summary>
        void When()
        {
            var repository = database.InjectContext(context => new CustomerRepository(context));
            var sut = new AddCustomerCommand(repository);
            dto = TestCustomer.Dto();

            sut.Execute(id, dto);
        }

        /// <summary>
        /// There must be registered customer information.
        /// </summary>
        void Then(CustomerViewModel expected)
        {
            var query = database.InjectContext(context => new GetCustomerQuery(context));
            var result = query.Execute(id);

            result.Should().BeEquivalentTo(expected);
        }

        [Fact(DisplayName = "There must be registered customer information when we register customer information.")]
        void Run()
        {
            Given();
            When();

            var expected = new CustomerViewModel
            {
                Id = id,
                BankAccountNumber = dto.BankAccountNumber,
                DateOfBirth = dto.DateOfBirth,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                CountryCode = dto.CountryCode,
                PhoneNumber = dto.PhoneNumber
            };

            Then(expected);
        }
    }
}
