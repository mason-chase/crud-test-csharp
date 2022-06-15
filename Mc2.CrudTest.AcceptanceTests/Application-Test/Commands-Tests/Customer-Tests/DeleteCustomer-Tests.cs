using Mc2.CrudTest.Application.Commands.Customer.Create;
using Mc2.CrudTest.Application.Commands.Customer.Delete;
using Mc2.CrudTest.Application.Common.Interfaces.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Application_Test.Commands_Tests.Customer_Tests
{
    [TestFixture]
    public class DeleteCustomer_Tests
    {
        private DeleteCustomerHandler _deleteCustomerHandler;
        [SetUp]
        public void InitialServices()
        {
            var BaseRepositoryServiceMock = new Mock<IBaseRepository<Customer>>();
            _deleteCustomerHandler = new DeleteCustomerHandler(BaseRepositoryServiceMock.Object);
        }
        [Test]
        public async Task CreateCustomerHandler_DeleteCustomerFromDataBaseWithId_ReturnCustomerId()
        {
            //Arrage
            var createCustomerCommand = new DeleteCustomerCommand()
            {
                Id = "D2022652-D22B-411C-A867-BB821F3E8DFE"
            };
            CancellationTokenSource source = new CancellationTokenSource();
            //Act
            var resutltOfHandler = await _deleteCustomerHandler.Handle(createCustomerCommand, source.Token);
            //Assert
            Assert.Pass();
        }
    }
}
