using Mc2.CrudTest.Application.Commands.Customer.Create;
using Mc2.CrudTest.Application.Common.Interfaces.Repository;
using Mc2.CrudTest.Domain.DomainService.Customer;
using Moq;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests.Application_Test.Commands_Tests.Customer_Tests
{
    [TestFixture]
    public class CreateCommandTests
    {
        private CreateCustomerHandler _createCustomerHandler;
        [SetUp]
        public void InitialServices()
        {
            var BaseRepositoryServiceMock = new Mock<IBaseRepository<Customer>>();
            _createCustomerHandler = new CreateCustomerHandler(BaseRepositoryServiceMock.Object);
        }
        [Test]
        public async Task CreateCustomerHandler_CreateNewCustomerInDataBase_ReturnCustomerId()
        {
            //Arrage
            var createCustomerCommand = new CreateCustomerCommand()
            {
                FirstName = "MSoheil",
                LastName = "Davoudi",
                DateOfBirthDay = DateTime.Now.ToString(),
                PhoneNumber = "09130611643",
                Email = "moh99soheil@gmail.com",
                BankAccountNumber = "314164646464666446",
                RegionOfPhoneNumber = "IR"
            };
            CancellationTokenSource source = new CancellationTokenSource();
            //Act
            var resutltOfHandler = await _createCustomerHandler.Handle(createCustomerCommand, source.Token);
            //Assert
            Assert.NotNull(resutltOfHandler);
        }


    }
}
