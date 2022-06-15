using Mc2.CrudTest.Application.Commands.Customer.Create;
using Mc2.CrudTest.Application.Common.Interfaces.Repository;
using Mc2.CrudTest.Application.Queries.Customer.GetAll;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Application_Test.Queries_Tests.Customer
{
    [TestFixture]
    public class GetAllCustomers_Test
    {
        private GetAllCustomerHandler _getAllCustomerQuery;


        [SetUp]
        public void InitialServices()
        {
            var BaseRepositoryServiceMock = new Mock<IBaseRepository<Mc2.CrudTest.Domain.Entities.Customer>>();
            _getAllCustomerQuery = new GetAllCustomerHandler(BaseRepositoryServiceMock.Object);
        }
        [Test]
        public async Task CreateCustomerHandler_GetAllCustomersFromDataBase_ReturnCustomerId()
        {
            //Arrage

            var getAllCustomerQuery = new GetAllCustomerQuery
            {
                PageNumber = 1,
                PageSize = 1
            };
            CancellationTokenSource source = new CancellationTokenSource();
            //Act
            var resutltOfHandler = await _getAllCustomerQuery.Handle(getAllCustomerQuery, source.Token);
            //Assert
            Assert.NotNull(resutltOfHandler);
        }
    }
}
