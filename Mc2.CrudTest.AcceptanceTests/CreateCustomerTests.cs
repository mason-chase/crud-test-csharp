using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    [TestClass]
    public class BddTddTests
    {
        [TestMethod]
        public void CreateCustomerValid_ReturnsSuccess()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "a@a.com";
            var phoneNumber = "+3197010265373";
            var dateOfBirth = new DateTime(1985, 2, 1);
            string bankAccountNumber = "0123-4567-8912-3456";
            //Act
            var customer = new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);

            //Assert
            Assert.IsNotNull(customer);
        }

        [TestMethod]
        public void Create_CustomerInvalidPhone_ReturnFail()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "a@a.com";
            var phoneNumber = "+31654";
            var dateOfBirth = new DateTime(1985, 2, 1);
            string bankAccountNumber = "0123-4567-8912-3456"; ;

            //Act - Assert
            Action a = () => new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);
            Assert.ThrowsException<ArgumentException>(a);

        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Create_CustomerBadBankAccount_ReturnFail()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "a@a.com";
            var phoneNumber = "+3197010265373";
            var dateOfBirth = new DateTime(1985, 2, 1);
            var bankAccountNumber = "6546468";

            //Act - Assert
            Assert.ThrowsException<ArgumentException>(() => new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

        }

        [TestMethod]
        public void Create_CustomerBadEmail_ReturnFail()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "aa.com";
            var phoneNumber = "+3197010265373";
            var dateOfBirth = new DateTime(1985, 2, 1);
            string bankAccountNumber = "0123-4567-8912-3456";

            //Act - Assert
            Assert.ThrowsException<ArgumentException>(() => new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

        }


        [TestMethod]
        public void Create_CustomerNotUnique_ReturnFail()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "a@a.com";
            var phoneNumber = "+3197010265373";
            var dateOfBirth = new DateTime(1985, 2, 1);
            string bankAccountNumber = "0123-4567-8912-3456";

            var customer2 = new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, "a@d.com",bankAccountNumber);

            //Act - Assert
            Assert.ThrowsException<Exception>(() => new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

        }

        [TestMethod]
        public void Create_CustomerEMailNotUnique_ReturnFail()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "a@a.com";
            var phoneNumber = "+3197010265373";
            var dateOfBirth = new DateTime(1985, 2, 1);
            string bankAccountNumber = "0123-4567-8912-3456";

            //Act - Assert
            Assert.ThrowsException<Exception>(() => new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

        }


        // Please create more tests based on project requirements as per in readme.md
    }
}
