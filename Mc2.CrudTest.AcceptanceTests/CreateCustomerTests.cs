using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xunit;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class BddTddTests
    {
        [Fact]
        public void CreateCustomerValid_ReturnsSuccess()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "a@a.com";
            var phoneNumber = "+989010596159";
            var dateOfBirth = new DateTime(1985, 2, 1);
            var bankAccountNumber = 123456;
            //Act
            var customer = new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber);

            //Assert
            Assert.IsNotNull(customer);
        }

        [Fact]
        public void Create_CustomerInvalidPhone_ReturnFail()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "a@a.com";
            var phoneNumber = "111111";
            var dateOfBirth = new DateTime(1985, 2, 1);
            var bankAccountNumber = 123456;

            //Act - Assert
            Assert.ThrowsException<ArgumentException>(()=> new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, email, bankAccountNumber));

        }

        // Please create more tests based on project requirements as per in readme.md
    }
}
