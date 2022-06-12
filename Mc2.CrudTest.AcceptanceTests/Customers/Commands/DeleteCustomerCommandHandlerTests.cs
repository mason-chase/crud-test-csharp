using c2.CrudTest.Application.CommandHandler;
using c2.CrudTest.Application.Commands;
using Mc2.CrudTest.AcceptanceTests.Common;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests.Customers.Commands
{
    public class DeleteCustomerCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteCustomerCommandHandler_Success()
        {
            // Assange
            var handler = new DeleteCustomerByIdCommandHandler(_context);
            var customerIdTest = 1;

            // Act
            var customerId = await handler.Handle(new DeleteCustomerByIdCommand
            {
                Id = customerIdTest,
            }, CancellationToken.None);

            // Assert
            Assert.Null(_context.Customers.SingleOrDefault(customer => customer.Id == customerId));
        }
    }
}
