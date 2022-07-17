using Domain;
using Domain.AggregatesModel.CustomerAggregate;
using Domain.Seedwork;
using Infrastructure;
using Infrastructure.Repositories;
using Mc2.CrudTest.Presentation.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [TestMethod]
        public void Create_CustomerBadBankAccount_ReturnFail()
        {
            //Arrange
            var identity = new Guid().ToString();
            var firstName = "fakeCustomer";
            var lastName = "fakeCustomerFamily";
            var email = "a@a.com";
            var phoneNumber = "+3197010265373";
            var dateOfBirth = new DateTime(1985, 2, 1);
            var bankAccountNumber = "757";

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

            var customer1 = new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, "a@d.com", bankAccountNumber);
            var customer2 = new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, "b@b.com",bankAccountNumber);
            var data = new List<Customer> {
                new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, "a@d.com", bankAccountNumber),
                new Customer(identity, firstName, lastName, dateOfBirth, phoneNumber, "b@b.com",bankAccountNumber)

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            var _context = new Mock<CustomerContext>();

            //Set the context of mock object to  the data we created.
            _context.Setup(c => c.Customers).Returns(mockSet.Object);

            //Create instance of WorldRepository by injecting mock DbContext we created
            var  _repo = new CustomerRepository(_context.Object);

            _repo.Add(customer1);
            _repo.Add(customer2);

            var customers = _repo.GetAll();

            bool allUnique = customers
                .GroupBy(p => new { firstName, lastName, dateOfBirth})
                .All(g => g.Count() == 1);

            Assert.IsTrue(allUnique);
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
