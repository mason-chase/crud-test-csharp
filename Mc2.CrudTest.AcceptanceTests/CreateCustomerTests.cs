using FluentAssertions;
using Mc2.CrudTest.AcceptanceTests.MockData;
using Mc2.CrudTest.Presentation.Server.Controllers;
using Mc2.CrudTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class BddTddTests
    {
        [Fact]
        public async Task CreateCustomerValid_ReturnsSuccessAsync()
        {
            // Todo: Refer to readme.md 

            /// Arrange
            var customerService = new Mock<ICustomerService>();
            var newCustomer = CusatomersMockData.NewCustomer();
            var sut = new CustomersContoller(customerService.Object);

            /// Act
            var actionResult = await sut.AddAsync(newCustomer, It.IsAny<CancellationToken>());

            // /// Assert
            actionResult.Should().BeOfType<CreatedResult>();
            var result = actionResult as CreatedResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.Created);
        }

        // Please create more tests based on project requirements as per in readme.md
    }
}
