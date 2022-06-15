using Mc2.CrudTest.Application.Commands.Customer.Create;
using Mc2.CrudTest.Application.Commands.Customer.Edit;
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
    public class EditCommand_Tests
    {
        private EditCustomerHandler _editCustomerHandler;
        [SetUp]
        public void InitialServices()
        {
            var BaseRepositoryServiceMock = new Mock<IBaseRepository<Customer>>();
            _editCustomerHandler = new EditCustomerHandler(BaseRepositoryServiceMock.Object);
        }
        [Test]
        public async Task CreateCustomerHandler_EditeCustomerFromDataBase_ReturnCustomerId()
        {
            //Arrage
            var EditCustomerCommand = new EditCustomerCommand()
            {
                Id= "D2022652-D22B-411C-A867-BB821F3E8DFE",
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
            var resutltOfHandler = await _editCustomerHandler.Handle(EditCustomerCommand, source.Token);
            //Assert
            Assert.NotNull(resutltOfHandler);
        }
    }
}
