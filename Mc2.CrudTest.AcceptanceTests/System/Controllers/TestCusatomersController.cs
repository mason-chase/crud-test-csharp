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

namespace Mc2.CrudTest.AcceptanceTests.System.Controllers
{
	public class TestCusatomersController
    {
        [Fact]
        public async Task GetAllAsync_ShouldReturn200Status()
        {
            /// Arrange
            var customerService = new Mock<ICustomerService>();
            customerService.Setup(users => users.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(CusatomersMockData.GetCustomers()
            );
            var sut = new CustomersContoller(customerService.Object);

            /// Act
            var actionResult = await sut.GetAllAsync(It.IsAny<CancellationToken>());

            // /// Assert
            actionResult.Result.Should().BeOfType<OkObjectResult>();
            var result = actionResult.Result as OkObjectResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturn204NoContentStatus()
        {
            /// Arrange
            var customerService = new Mock<ICustomerService>();
            customerService.Setup(users =>
                users.GetAllAsync(It.IsAny<CancellationToken>()))
                    .ReturnsAsync(CusatomersMockData.GetEmptyCustomers()
            );
            var sut = new CustomersContoller(customerService.Object);

            /// Act
            var actionResult = await sut.GetAllAsync(It.IsAny<CancellationToken>());

            /// Assert
            actionResult.Result.Should().BeOfType<NoContentResult>();
            var result = actionResult.Result as NoContentResult;
            result.StatusCode.Should().Be((int)HttpStatusCode.NoContent);
            customerService.Verify(_ => _.GetAllAsync(It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task AddAsync_ShouldCall_ICustomerService_AddAsync_AtleastOnce()
        {
            /// Arrange
            var customerService = new Mock<ICustomerService>();
            var newCustomer = CusatomersMockData.NewCustomer();
            var sut = new CustomersContoller(customerService.Object);

            /// Act
            var result = await sut.AddAsync(newCustomer, It.IsAny<CancellationToken>());

            /// Assert
            customerService.Verify(_ => _.AddAsync(newCustomer, It.IsAny<CancellationToken>(), true));
        }
    }
}