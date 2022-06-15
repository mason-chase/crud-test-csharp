using Mc2.CrudTest.Domain.DomainService.Customer;

namespace Mc2.CrudTest.AcceptanceTests.DomainService
{
    [TestFixture]
    public class DomainServiceTests
    {
        [Test]
        public void CheckMobileValidation_InputUserPhoneNumberCheckValidation_ReturnTrue()
        {
            //Arrange
            var phoneNumber = "351649787";
            var region = "IR";
            var customerDomainService = new CustomerDomainService();
            //Act
            var resultOfCheckValidation = customerDomainService.CheckPhoneNumberValidation(phoneNumber, region);
            //Assert
            Assert.IsTrue(resultOfCheckValidation);

        }


    }
}
