

namespace Mc2.CrudTest.AcceptanceTests
{
    [TestFixture]
    public class BddTddTests
    {
        string firstName = "";
        string lastName = "";
        string dateOfBirth;
        string phoneNumber = "";
        string email = "";
        string bankAccountNumber = "";
        [SetUp]
        public void InitialData()
        {
            firstName = "MSoheil";
            lastName = "Davoudi";
            dateOfBirth = DateTime.UtcNow.ToString();
            phoneNumber = "09130611643";
            email = "Moh99soheil@gmial.com";
            bankAccountNumber = "4003830171874018";
        }

        [Test]
        public void CustomerEntity_CreateNewinstance_ReturnInstanceSuccessfuly()
        {
            //Arrange
            //Act
            var customer = new Customer(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
            //Assert
            Assert.Pass();

        }

        [Test]
        public void CustomerEntity_CreateNewInstanceAndSendNullFirstName_ReturnExeptionAndPassTest()
        {
            //Arrange
            firstName = null;
            try
            {
                //Act
                var customer = new Customer(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
                //Assert
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void CustomerEntity_CreateNewInstanceAndSendNullLastName_ReturnExeptionAndPassTest()
        {
            //Arrange
            lastName = null;
            try
            {
                //Act
                var customer = new Customer(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
                //Assert
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void CustomerEntity_CreateNewInstanceAndSendNullDateOfBirthday_ReturnExeptionAndPassTest()
        {
            //Arrange
            dateOfBirth = null;
            try
            {
                //Act
                var customer = new Customer(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
                //Assert
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void CustomerEntity_CreateNewInstanceAndSendNullPhoneNumber_ReturnExeptionAndPassTest()
        {
            //Arrange
            phoneNumber = null;
            try
            {
                //Act
                var customer = new Customer(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
                //Assert
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void CustomerEntity_CreateNewInstanceAndSendNullBankAccount_ReturnExeptionAndPassTest()
        {
            //Arrange
            bankAccountNumber = null;
            try
            {
                //Act
                var customer = new Customer(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
                //Assert
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void CustomerEntity_CreateNewInstanceAndSendNullEmail_ReturnExeptionAndPassTest()
        {
            //Arrange
            bankAccountNumber = null;
            try
            {
                //Act
                var customer = new Customer(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
                //Assert
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void CustomerEntity_CreateNewInstanceAndSendBiggerThan15CharacterPhoeNumber_ReturnExeptionAndPassTest()
        {
            //Arrange
            phoneNumber = "0913061164365496";
            try
            {
                //Act
                var customer = new Customer(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
                //Assert
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }
        [Test]
        public void CustomerEntity_CreateNewInstanceAndSendBiggerThan30CharacterBankAccountNumber_ReturnExeptionAndPassTest()
        {
            //Arrange
            bankAccountNumber = "12345678912345678945612312346569874";
            try
            {
                //Act
                var customer = new Customer(firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
                //Assert
                Assert.Fail();
            }
            catch (Exception)
            {
                Assert.Pass();
            }
        }
    }
}
