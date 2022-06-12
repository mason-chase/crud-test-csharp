using c2.CrudTest.Application.Queries;
using c2.CrudTest.Application.QueriesHandler;
using Mc2.CrudTest.AcceptanceTests.Common;
using System.Linq;
using System.Threading;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Customers
{
    public class GetCustomerListQueryHandlerTests : TestCommandBase
    {
        [Fact]
        public async void GetCustomerListQueryHandler_Success()
        {
            // Arrenge
            var handler = new GetAllCustomersQueryHandler(_context);

            // Act
            var customerList = await handler.Handle(
                new GetAllCustomersQuery(), CancellationToken.None);

            // Assert
            Assert.NotEmpty(customerList); 
        }
    }
}
