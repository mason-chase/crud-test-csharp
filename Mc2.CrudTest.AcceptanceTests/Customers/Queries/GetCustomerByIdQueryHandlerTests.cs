using c2.CrudTest.Application.Queries;
using c2.CrudTest.Application.QueriesHandler;
using Mc2.CrudTest.AcceptanceTests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Customers.Queries
{
    [Collection("QueryCollection")]
    public class GetCustomerByIdQueryHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task GetCustomerByIdQueryHandler_MatchResult()
        {
            // Arrange
            var handler = new GetCustomerByIdQueryHandler(_context);
            var customerIdTest = 1;

            var id = 1;
            var firstName = "taher 1";
            var lastName = "fattahi 1";
            var dateOfBirth = new DateTime(2022, 3, 15, 6, 0, 0);
            ulong phoneNumber = 989115467885;
            var email = "taherfatta11@gmail.com";
            var bankAccountNumber = "6037-9917-0000-0000";

            // Act
            var customer = await handler.Handle(
                new GetCustomerByIdQuery
                {
                    Id = customerIdTest
                },
                CancellationToken.None);

            // Assert
            Assert.Equal(id, customer.Id);
            Assert.Equal(firstName, customer.FirstName);
            Assert.Equal(lastName, customer.LastName);
            Assert.Equal(dateOfBirth, customer.DateOfBirth);
            Assert.Equal(phoneNumber, customer.PhoneNumber);
            Assert.Equal(email, customer.Email);
            Assert.Equal(bankAccountNumber, customer.BankAccountNumber);
        }
    }
}
