using Mc2.CrudTest.Application.Common.Interfaces.Repository;
using Mc2.CrudTest.Application.Queries.Customer.GetAll;
using Mc2.CrudTest.Application.Queries.Customer.GetById;
using Moq;

namespace Mc2.CrudTest.AcceptanceTests.Application_Test.Queries_Tests.Customer
{


    [TestFixture]
    public class GetOneById_Test
    {
        private GetCustomerByIdHandler _getCustomerByIdHandler;

        [SetUp]
        public void InitialServices()
        {
            var BaseRepositoryServiceMock = new Mock<IBaseRepository<Mc2.CrudTest.Domain.Entities.Customer>>();
            _getCustomerByIdHandler = new GetCustomerByIdHandler(BaseRepositoryServiceMock.Object);
        }
        [Test]
        public async Task CreateCustomerHandler_GetCustomerFromDataBaseWithId_ReturnCustomerId()
        {
            //Arrage

            var getCustomerByIdQuery = new GetCustomerByIdQuery
            {
                Id= "f62518c0-44ce-4646-877d-c96e660adc01"
            };
            CancellationTokenSource source = new CancellationTokenSource();
            //Act
            var resutltOfHandler = await _getCustomerByIdHandler.Handle(getCustomerByIdQuery, source.Token);
            //Assert
            Assert.NotNull(resutltOfHandler);
        }
    }
}
